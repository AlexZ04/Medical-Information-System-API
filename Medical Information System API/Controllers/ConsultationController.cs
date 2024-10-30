using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/consultation")]
    public class ConsultationController : Controller
    {
        private readonly DataContext _context;

        public ConsultationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetConsultations()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetConcreteConsultation(Guid id)
        {
            var cons = await _context.Consultations
                .Include(c => c.Speciality)
                .Include(c => c.Comments).ThenInclude(c => c.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (cons == null) return BadRequest();

            return Ok(new ConsultationModel(cons));
        }
    }
}
