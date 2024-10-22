using Medical_Information_System_API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/consultation")]
    public class DictionaryController : Controller
    {
        private readonly DataContext _context;

        public DictionaryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("speciality")]
        public async Task<IActionResult> GetSpecialities()
        {
            var consultationList = await _context.SpecialitiesList.ToListAsync();

            return Ok(consultationList);
        }
    }
}
