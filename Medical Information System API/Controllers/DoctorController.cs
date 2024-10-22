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

            var token = _tokenManager.CreateTokenByName(doctor.Id);

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

            var token = _tokenManager.CreateTokenByName(foundUser.Id);

            return Ok(new TokenResponseModel(token));
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> PostLogout()
        {
            // Redis 
            // или пихать токены в бд, каждые 30 минут проверять разницу между текущим временем и временем добавления токена в базу
            // если время больше 30 минут, удалять токен
            return Ok();
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null) {
                return Unauthorized();
            }

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null)
            {
                return Unauthorized();
            }

            loginnedDoctor.Password = "";
            var doctor = new DoctorModel(loginnedDoctor);

            return Ok(doctor);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromBody] DoctorEditModel newDoctor)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null)
            {
                return Unauthorized();
            }

            loginnedDoctor.Email = newDoctor.Email;
            loginnedDoctor.Name = newDoctor.Name;
            loginnedDoctor.Birthday = newDoctor.Birthday;
            loginnedDoctor.Gender = newDoctor.Gender;
            loginnedDoctor.Phone = newDoctor.Phone;

            _context.SaveChanges();

            loginnedDoctor.Password = "";

            return Ok();
        }
    }
}
