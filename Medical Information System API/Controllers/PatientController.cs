﻿using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.IcdTree;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography.Xml;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<PatientController> _logger;

        public PatientController(DataContext context, ILogger<PatientController> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// Create new patient
        /// </summary>
        /// <response code="200">Patient was registered</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(GuidResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePatient([FromBody] PatientCreateModel patientCreateModel)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest();

            var patient = new Patient(patientCreateModel);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok(new GuidResponseModel { Id = patient.Id });
        }


        /// <summary>
        /// Get patient list
        /// </summary>
        /// <response code="200">Patients paged list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination/sorting</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(PatientPagedListModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPatientList([FromQuery] string? name, [FromQuery] List<Conclusion?> conslusion,
            [FromQuery] SortOptions? sorting,
            [FromQuery] bool scheduledVisits = false, [FromQuery] bool onlyMine = false, 
            [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            if (page <= 0 || size <= 0) return BadRequest(new ResponseModel("Error", "Invalid value for pagination"));

            if (name == null) name = "";

            name = name.ToLower();

            var patientList = _context.Patients
                .Where(p => p.Name.Contains(name));

            patientList = patientList.Where(p => p.Name.ToLower().Contains(name.ToLower()));


            if (onlyMine) {
                if (User.FindFirst(ClaimTypes.NameIdentifier)?.Value == null) return Unauthorized();

                var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                var patientsId = await _context.Inspections
                    .Include(i => i.Patient).Include(i => i.Doctor)
                    .Where(i => i.Doctor.Id == userId)
                    .Select(i => i.Patient.Id).Distinct()
                    .ToListAsync();

                patientList = patientList.Where(p => patientsId.Contains(p.Id));
            }


            if (scheduledVisits)
            {
                var patientsId = await _context.Inspections
                    .Where(i => i.Date > DateTime.Now.ToUniversalTime())
                    .Select(i => i.Patient.Id).Distinct().ToListAsync();

                patientList = patientList.Where(p => patientsId.Contains(p.Id));
            }


            if (conslusion != null && conslusion.Count > 0)
            {
                var availablePatients = await _context.Inspections
                    .Include(i => i.Patient)
                    .Where(i => conslusion.Contains(i.Conclusion))
                    .Select(i => i.Patient).Distinct()
                    .ToListAsync();
                
                if (conslusion[0] == null)
                {
                    var patientsWithoutInsp = await _context.Patients
                        .Where(p => 
                        !_context.Inspections.Include(i => i.Patient).Any(i => i.Patient == p))
                        .ToListAsync();

                    availablePatients.AddRange(patientsWithoutInsp);
                }

                patientList = patientList.Where(p => availablePatients.Contains(p));
            }


            switch (sorting)
            {
                case SortOptions.NameAsc:
                    patientList = patientList.OrderBy(p => p.Name);
                    break;

                case SortOptions.NameDesc:
                    patientList = patientList.OrderByDescending(p => p.Name);
                    break;

                case SortOptions.CreateAsc:
                    patientList = patientList.OrderBy(p => p.CreateTime);
                    break;

                case SortOptions.CreateDesc:
                    patientList = patientList.OrderByDescending(p => p.CreateTime);
                    break;

                case SortOptions.InspectionAsc:
                    patientList = patientList.OrderBy(p => p.LastInspectionDate);
                    break;

                case SortOptions.InspectionDesc:
                    patientList = patientList.OrderByDescending(p => p.LastInspectionDate);
                    break;
            }


            patientList = patientList.Skip((page - 1) * size).Take(size);

            int amount = await patientList.CountAsync();
            var patientRes = await patientList.ToListAsync();

            var resList = new List<PatientModel>();


            foreach (var patient in patientRes)
            {
                resList.Add(new PatientModel(patient));
            }


            var count = (int)Math.Ceiling(amount * 1.0 / size);

            if (page > count && count > 0) return BadRequest(new ResponseModel("Error", "Page number must be less than pages count"));

            var resModel = new PatientPagedListModel(resList, new PageInfoModel(size, count, page));

            return Ok(resModel);
        }


        /// <summary>
        /// Create inspection for specified patient
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(GuidResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost("{id}/inspections")]
        [Authorize]
        public async Task<IActionResult> CreateInspection(Guid id, [FromBody] InspectionCreateModel inspection)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest();

            var patient = await _context.Patients.FindAsync(id);

            if (patient == null) return NotFound(new ResponseModel("Error", "Can't found patient with this Id"));

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            if (inspection.PreviousInspectionId != null)
            {
                var prevInsp = _context.Inspections.Find(inspection.PreviousInspectionId);
                if (prevInsp == null) return NotFound(new ResponseModel("Error", "Can't found previous inspection"));

                if (inspection.Date <= prevInsp.Date) 
                    return BadRequest(new ResponseModel("Error", "Child inspection can't be early than parent inspection"));
            }

            if (inspection.Date > DateTime.Now.ToUniversalTime()) 
                return BadRequest(new ResponseModel("Error", "Invalid inspection date"));

            if (patient.HealthStatus == Conclusion.Death) 
                return BadRequest(new ResponseModel("Error", "You can't inspect this patient anymore. It's too late"));

            if (inspection.Conclusion == Conclusion.Death && inspection.DeathDate == null)
                return BadRequest(new ResponseModel("Error", "DeathDate must be filled"));

            if (inspection.Conclusion == Conclusion.Death && inspection.NextVisitDate != null) 
                return BadRequest(new ResponseModel("Error", "Patient dead :("));

            if (inspection.Conclusion != Conclusion.Death && inspection.DeathDate != null)
                return BadRequest(new ResponseModel("Error", "Patient not dead!"));

            if (inspection.Conclusion == Conclusion.Disease && inspection.NextVisitDate == null)
                return BadRequest(new ResponseModel("Error", "NextVisitDate must be not null because of disease"));

            if (inspection.NextVisitDate != null && (inspection.NextVisitDate < DateTime.Now.ToUniversalTime()
                || inspection.NextVisitDate < inspection.Date))
                return BadRequest(new ResponseModel("Error", "Invalid NextVisitDate value"));

            if (inspection.Conclusion == Conclusion.Recovery && (inspection.NextVisitDate != null || inspection.DeathDate != null))
                return BadRequest(new ResponseModel("Error", "Patient recovered"));

            if (inspection.DeathDate != null && inspection.DeathDate > DateTime.Now.ToUniversalTime())
                return BadRequest(new ResponseModel("Error", "Death date can't be later then now..."));


            List<Diagnose> diagnosesList = new List<Diagnose>();

            foreach (var diagnoseModel in inspection.Diagnoses)
            {
                var Icd10Rec = _context.Icd10.Find(diagnoseModel.IcdDiagnosisId);

                if (Icd10Rec == null) return BadRequest();

                var createdDiagnose = new Diagnose(diagnoseModel, Icd10Rec);

                diagnosesList.Add(createdDiagnose);
                _context.Diagnoses.Add(createdDiagnose);
            }


            List<Consultation> consultationList = new List<Consultation>();

            var inspectionId = Guid.NewGuid();

            var spetialitiesList = new List<Guid>();

            foreach (var consultationModel in inspection.Consultations ?? [])
            {
                var speciality = await _context.SpecialitiesList.FindAsync(consultationModel.SpecialityId);

                if (speciality == null) return BadRequest();

                spetialitiesList.Add(speciality.Id);

                var commentModel = consultationModel.Comment;
                var createComment = new Comment(commentModel, loginnedDoctor);

                _context.Comments.Add(createComment);

                var createdConsultation = new Consultation(speciality, inspectionId, createComment, loginnedDoctor.Id);

                consultationList.Add(createdConsultation);
                _context.Consultations.Add(createdConsultation);
            }

            var spetialitiesListDist = spetialitiesList.Distinct().ToList();

            if (spetialitiesList.Count != spetialitiesListDist.Count) 
                return BadRequest(new ResponseModel("Error", "One inspection can't have 2 consultations with doctors with one speciality"));


            int groupNumber = 0;
            if (inspection.PreviousInspectionId != null)
            {
                var parentId = _context.Inspections.Find(inspection.PreviousInspectionId);
                groupNumber = parentId != null ? parentId.Group : 0;
            }
            else
            {
                if (_context.Inspections.Count() == 0) groupNumber = 0;
                else
                {
                    var lastAddedInsp = _context.Inspections
                        .OrderByDescending(i => i.CreateTime)
                        .First();
                    if (lastAddedInsp != null)
                    {
                        groupNumber = lastAddedInsp.Group + 1;
                    }
                }  
            }


            var createdInspection = new Inspection(inspection, patient, loginnedDoctor, diagnosesList, consultationList,
                inspectionId, groupNumber);
            _context.Inspections.Add(createdInspection);

            if (patient.LastInspectionDate == null || createdInspection.Date > patient.LastInspectionDate)
            {
                patient.LastInspectionDate = createdInspection.Date;
                patient.HealthStatus = createdInspection.Conclusion;
            }

            await _context.SaveChangesAsync();

            loginnedDoctor.Password = "";

            return Ok(new GuidResponseModel() { Id = inspectionId });
        }


        /// <summary>
        /// Get a list of patient medical inspections
        /// </summary>
        /// <response code="200">Patients inspections list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(InspectionPagedListModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}/inspections")]
        [Authorize]
        public async Task<IActionResult> GetInspectionsList(Guid id,
            [FromQuery] List<Guid> icdRoots, [FromQuery] bool grouped = false,
            [FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            if (page <= 0 || size <= 0) return BadRequest(new ResponseModel("Error", "Invalid value for pagination"));

            foreach (var icdRoot in icdRoots)
            {
                var record = _context.Icd10.Find(icdRoot);

                if (record == null) return BadRequest(new ResponseModel("Error", "Can't find ICD-10 record"));

                if (record.ParentId != null) return BadRequest(new ResponseModel("Error", "One or mode Guid's is not the root ICD"));
            }

            var inspFromContext = _context.Inspections
                .Include(i => i.Patient).Include(i => i.Doctor)
                .Include(i => i.Diagnoses).ThenInclude(d => d.Record)
                .Include(i => i.Consultations).ThenInclude(c => c.Comments)
                .Where(x => x.Patient.Id == id);

            try
            {

                if (icdRoots.Count > 0)
                {
                    inspFromContext = inspFromContext.
                    Where(i => i.Diagnoses.Any(d => icdRoots.Contains(d.Record.RootId) &&
                    d.Type == DiagnosisType.Main));
                }
            }
            catch (ObjectDisposedException ex)
            {
                _logger.LogError(ex.ToString());
            }


            if (grouped)
            {
                inspFromContext = inspFromContext.
                    OrderBy(x => x.Group).ThenBy(x => x.CreateTime);
            }


            inspFromContext = inspFromContext
                .Skip((page - 1) * size).Take(size);

            var inspections = await inspFromContext.ToListAsync();

            List<InspectionPreviewModel> list = new List<InspectionPreviewModel>();
            bool hasChain = false, hasNested = false;

            foreach (var inspection in inspections) {
                var childInsp = await _context.Inspections
                    .FirstOrDefaultAsync(i => i.PreviousInspectionId == inspection.Id);

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

            if (page > count && count > 0) return BadRequest(new ResponseModel("Error", "Page number must be less than pages count"));

            var res = new InspectionPagedListModel(list, new PageInfoModel(size, count, page));

            return Ok(res);
        }


        /// <summary>
        /// Get patient card
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(PatientModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPatientCard(Guid id)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var patient = await _context.Patients.FindAsync(id);

            return patient != null ? Ok(new PatientModel(patient)) : NotFound();
        }


        /// <summary>
        /// Search for patient medical inspections without child inspections
        /// </summary>
        /// <response code="200">Patients inspections list retrieved</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Patient not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<InspectionShortModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}/inspection/search")]
        [Authorize]
        public async Task<IActionResult> SearchInspWithoutChild(Guid id, [FromQuery] string? request)
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var patient = _context.Patients.Find(id);
            if (patient == null) return NotFound();

            List<InspectionShortModel> result = new List<InspectionShortModel>();

            if (request == null) request = "";
            request = request.ToLower();

            var inspections = await _context.Inspections
                .Include(i => i.Patient).Include(i => i.Doctor)
                .Include(i => i.Diagnoses).ThenInclude(d => d.Record)
                .Include(i => i.Consultations).ThenInclude(c => c.Comments)
                .Include(i => i.Consultations).ThenInclude(c => c.Speciality)

                .Where(x => x.Patient.Id == id && 
                    x.Diagnoses.Any(d => d.Record.Name.ToLower().StartsWith(request) || d.Record.Code.ToLower().Contains(request)))

                .ToListAsync();


            foreach (var inspection in inspections)
            {
                var childInsp = await _context.Inspections.FirstOrDefaultAsync(x => x.PreviousInspectionId == inspection.Id);

                if (childInsp == null) result.Add(new InspectionShortModel(inspection));
            }

            return Ok(result);
        }

    }
}
