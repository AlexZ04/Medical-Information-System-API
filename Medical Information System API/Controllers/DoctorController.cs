using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Helpers;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly DataContext _context;
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        private TokenManager _tokenManager = new TokenManager();

        public DoctorController(ILogger<DoctorController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostRegister([FromBody] DoctorRegisterModel doctorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var doctor = await _context.Doctors.FindAsync(doctorDTO.Email);

            if (doctor != null)
            {
                return BadRequest("This email is already used");
            }

            var newDoctor = new DoctorDatabase(doctorDTO);
            _context.Doctors.Add(newDoctor);
            await _context.SaveChangesAsync();

            var token = _tokenManager.CreateTokenByName(doctorDTO.Email);

            return Ok(new TokenResponseModel(token));
        }

        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginCredentialsModel loginData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var foundUser = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == loginData.Email);

            if (foundUser == null || !Crypto.VerifyHashedPassword(foundUser.Password, loginData.Password))
            {
                return BadRequest();
            }

            foundUser.Password = "";

            var token = _tokenManager.CreateTokenByName(foundUser.Email);

            return Ok(new TokenResponseModel(token));
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> PostLogout()
        {
            var userEmail = User.FindFirst(ClaimTypes.Name)?.Value;

            _logger.LogInformation(userEmail);

            var loginnedDoctor = await _context.Doctors.FindAsync(userEmail);

            if (loginnedDoctor == null)
            {
                return Unauthorized();
            }

            loginnedDoctor.Password = "";
            var doctor = new DoctorModel(loginnedDoctor);


            return Ok(doctor);
        }
    }
}
