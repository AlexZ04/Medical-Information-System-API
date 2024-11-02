using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : Controller
    {
        private readonly DataContext _context;

        public PatientController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePatient([FromBody] PatientCreateModel patientCreateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var patient = new Patient(patientCreateModel);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPatientList([FromQuery] string name, [FromQuery] List<Conclusion> conslusion,
            [FromQuery] SortOptions sorting,
            [FromQuery] bool scheduledVisits = false, [FromQuery] bool onlyMine = false, 
            [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var patientList = await _context.Patients.ToListAsync();

            return Ok(patientList);
        }

        [HttpPost("{id}/inspections")]
        [Authorize]
        public async Task<IActionResult> CreateInspection(Guid id, [FromBody] InspectionCreateModel inspection)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null) return BadRequest();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            List<Diagnose> diagnosesList = new List<Diagnose>();

            foreach (var diagnoseModel in inspection.Diagnoses)
            {
                var Icd10Rec = await _context.Icd10.FindAsync(diagnoseModel.IcdDiagnosisId);

                if (Icd10Rec == null) return BadRequest();

                var createdDiagnose = new Diagnose(diagnoseModel, Icd10Rec);

                diagnosesList.Add(createdDiagnose);
                _context.Diagnoses.Add(createdDiagnose);
            }

            List<Consultation> consultationList = new List<Consultation>();

            var inspectionId = Guid.NewGuid();

            foreach (var consultationModel in inspection.Consultations)
            {
                var speciality = await _context.SpecialitiesList.FindAsync(consultationModel.SpecialityId);

                if (speciality == null) return BadRequest();

                var commentModel = consultationModel.Comment;
                var createComment = new Comment(commentModel, loginnedDoctor);

                _context.Comments.Add(createComment);

                var createdConsultation = new Consultation(speciality, inspectionId, createComment);

                consultationList.Add(createdConsultation);
                _context.Consultations.Add(createdConsultation);
            }

            var createdInspection = new Inspection(inspection, patient, loginnedDoctor, diagnosesList, consultationList, inspectionId);
            _context.Inspections.Add(createdInspection);
            await _context.SaveChangesAsync();

            return Ok(inspectionId);
        }

        [HttpGet("{id}/inspections")]
        [Authorize]
        public async Task<IActionResult> GetInspectionsList(Guid id, [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var inspections = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .Where(x => x.Patient.Id == id)
                .Skip((page - 1) * size).Take(size)
                .ToListAsync();

            List<InspectionPreviewModel> list = new List<InspectionPreviewModel>();
            bool hasChain = false, hasNested = false;

            foreach (var inspection in inspections) {
                var childInsp = await _context.Inspections.FirstOrDefaultAsync(x => x.PreviousInspectionId == inspection.Id);

                if (childInsp != null) {
                    hasNested = true;

                    if (inspection.PreviousInspectionId != null) hasChain = false;
                    else hasChain = true;
                }
                else
                {
                    hasChain = false;
                    hasNested = false;
                }

                var previewModel = new InspectionPreviewModel(inspection, hasChain, hasNested);

                list.Add(previewModel);
            }

            var amount = await _context.Inspections.CountAsync();
            var count = (int)Math.Ceiling(amount * 1.0 / size);

            var res = new InspectionPagedListModel(list, new PageInfoModel(size, count, page));

            return Ok(res);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPatientCard(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);

            return patient != null ? Ok(new PatientModel(patient)) : NotFound();
        }

        [HttpGet("{id}/inspection/search")]
        [Authorize]
        public async Task<IActionResult> SearchInspWithoutChild(Guid id)
        {
            List<InspectionShortModel> result = new List<InspectionShortModel>();

            var inspections = await _context.Inspections
                .Include(x => x.Patient).Include(x => x.Doctor)
                .Include(x => x.Diagnoses).ThenInclude(d => d.Record)
                .Include(x => x.Consultations).ThenInclude(c => c.Comments)
                .Include(x => x.Consultations).ThenInclude(c => c.Speciality)
                .Where(x => x.Patient.Id == id).ToListAsync();

            foreach (var inspection in inspections)
            {
                var childInsp = await _context.Inspections.FirstOrDefaultAsync(x => x.PreviousInspectionId == inspection.Id);

                if (childInsp == null) result.Add(new InspectionShortModel(inspection));
            }

            return Ok(result);
        }

    }
}
