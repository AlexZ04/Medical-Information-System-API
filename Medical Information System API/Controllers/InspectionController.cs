using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            if (insp == null) return BadRequest();

            var res = new InspectionModel(insp);
            return Ok(res);
        }

        /// <summary>
        /// Edit concrete inspection
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditInspection(Guid id, [FromBody] InspectionEditModel model)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var insp = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .Include(x => x.Consultations).ThenInclude(c => c.Speciality)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insp == null) return BadRequest();

            var patient = insp.Patient;

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

            return Ok();
        }

        /// <summary>
        /// Get medical inspection chain for root inspection
        /// </summary>
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

            if (insp == null || insp.PreviousInspectionId != null) return BadRequest();

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
