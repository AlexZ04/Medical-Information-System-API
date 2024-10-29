using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
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

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetInspectionInfo(Guid id)
        {
            var insp = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insp == null) return BadRequest();

            var res = new InspectionModel(insp);
            return Ok(res);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditInspection(Guid id, [FromBody] InspectionEditModel model)
        {
            var insp = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insp == null) return BadRequest();

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

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}/chain")]
        [Authorize]
        public async Task<IActionResult> GetChain(Guid id)
        {
            var insp = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insp == null) return BadRequest();

            List<Inspection> chain = new List<Inspection>();
            bool flag = true;
            Guid currentId = insp.Id;

            while (flag)
            {
                var nextInsp = await _context.Inspections
                    .Include(x => x.Patient).Include(x => x.Doctor)
                    .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                    .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                    .FirstOrDefaultAsync(x => x.Id == currentId);

                if (nextInsp == null) flag = false;
                else
                {
                    chain.Add(nextInsp);
                    currentId = nextInsp.Id;
                }
                
            }

            return Ok(chain);
        }
    }
}
