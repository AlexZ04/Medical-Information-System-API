using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var patient = new PatientModel(patientCreateModel);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPatientList()
        {
            var patientList = await _context.Patients.ToListAsync();

            return Ok(patientList);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPatientCard(Guid id)
        {
            var patient = await _context.Patients.FindAsync(id);

            return patient != null ? Ok(patient) : NotFound();
        }

        [HttpPost("{id}/inspections")]
        [Authorize]
        public async Task<IActionResult> CreateInspection(Guid id, [FromBody] InspectionCreateModel inspect)
        {
            return Ok();
        }
    }
}
