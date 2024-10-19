using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(ILogger<DoctorController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Get([FromBody] DoctorRegisterModel doctorDTO)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                _logger.LogError("err");
                return BadRequest();
            }
        }
    }
}
