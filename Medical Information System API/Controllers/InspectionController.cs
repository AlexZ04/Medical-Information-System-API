using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/inspection")]
    public class InspectionController : Controller
    {
        private readonly DataContext _context;

        public InspectionController(DataContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Get full info about specified inspection
        /// </summary>
        /// <response code="200">Inspection found and successfully extracted</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(InspectionModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetInspectionInfo(Guid id)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var insp = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .Include(x => x.Consultations).ThenInclude(c => c.Speciality)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insp == null) return NotFound();

            var res = new InspectionModel(insp);
            return Ok(res);
        }


        /// <summary>
        /// Edit concrete inspection
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">User doesn't have editing rights (not the inspection author)</response>
        /// <response code="404">Inspection not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditInspection(Guid id, [FromBody] InspectionEditModel model)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest();

            var insp = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .Include(x => x.Consultations).ThenInclude(c => c.Speciality)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insp == null) return NotFound();


            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();

            var response = new ResponseModel("Error", "User is not the inspection creator").ToString();

            if (insp.Doctor.Id != new Guid(userId))
            {
                if (response != null) return Forbid(response);
                else return Forbid();
            }

            var patient = insp.Patient;


            if (patient.HealthStatus == Conclusion.Death && insp.Conclusion != Conclusion.Death)
                return BadRequest(new ResponseModel("Error", "Patient can't have 2 inspections with Death conslusion"));

            if (model.Conclusion == Conclusion.Disease && model.NextVisitDate == null)
                return BadRequest(new ResponseModel("Error", "NextVisitDate must be not null because of disease"));

            if (model.Conclusion != Conclusion.Death && model.NextVisitDate != null)
                return BadRequest(new ResponseModel("Error", "Patient not dead!"));

            if (model.Conclusion == Conclusion.Death && model.NextVisitDate != null)
                return BadRequest(new ResponseModel("Error", "Patient dead :("));

            if (model.Conclusion == Conclusion.Death && model.DeathDate == null)
                return BadRequest(new ResponseModel("Error", "DeathDate must be filled"));

            if (model.NextVisitDate != null && (model.NextVisitDate < DateTime.Now.ToUniversalTime() || 
                model.NextVisitDate < insp.Date))
                return BadRequest(new ResponseModel("Error", "Invalid NextVisitDate value"));


            insp.Anamnesis = model.Anamnesis;
            insp.Complaints = model.Complaints;
            insp.Treatment = model.Treatment;
            insp.Conclusion = model.Conclusion;
            insp.NextVisitDate = model.NextVisitDate;
            insp.DeathDate = model.DeathDate;

            var diagnoses = model.Diagnoses;

            List<Diagnose> newDiagnoses = new List<Diagnose>();


            foreach (var diagnose in insp.Diagnoses)
            {
                _context.Diagnoses.Remove(diagnose);
            }


            foreach (var diagnose in diagnoses)
            {
                var Icd10Rec = await _context.Icd10.FindAsync(diagnose.IcdDiagnosisId);

                if (Icd10Rec == null) return BadRequest();

                var createdDiagnose = new Diagnose(diagnose, Icd10Rec);

                newDiagnoses.Add(createdDiagnose);
                _context.Diagnoses.Add(createdDiagnose);
            }


            insp.Diagnoses = newDiagnoses;

            if (patient.LastInspectionDate == null || insp.Date >= patient.LastInspectionDate)
            {
                patient.LastInspectionDate = insp.Date;
                patient.HealthStatus = insp.Conclusion;
            }

            await _context.SaveChangesAsync();

            return Ok(new ResponseModel("Success", "Inspection successfully updated"));
        }


        /// <summary>
        /// Get medical inspection chain for root inspection
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<InspectionPreviewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}/chain")]
        [Authorize]
        public async Task<IActionResult> GetChain(Guid id)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var insp = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insp == null) return NotFound();
            if (insp.PreviousInspectionId != null) return BadRequest();

            List<InspectionPreviewModel> chain = new List<InspectionPreviewModel>();
            bool flag = true;
            Guid currentId = insp.Id;

            while (flag)
            {
                var nextInsp = await _context.Inspections.FirstOrDefaultAsync(x => x.PreviousInspectionId == currentId);

                if (nextInsp == null) flag = false;
                else
                {
                    chain.Add(new InspectionPreviewModel(nextInsp, false,
                        await _context.Inspections.FirstOrDefaultAsync(x => x.PreviousInspectionId == nextInsp.Id) != null
                        ));
                    currentId = nextInsp.Id;
                }

            }

            return Ok(chain);
        }
    }
}
