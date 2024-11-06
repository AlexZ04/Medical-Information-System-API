using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
using Newtonsoft.Json.Linq;
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
        private readonly TokenManager _tokenManager = new TokenManager();

        public DoctorController(ILogger<DoctorController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Register new user (doctor)
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> PostRegister([FromBody] DoctorRegisterModel doctorDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var doctor = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == doctorDTO.Email);

            if (doctor != null) return BadRequest("This email is already used");

            var foundSpec = await _context.SpecialitiesList.FirstOrDefaultAsync(u => u.Id == doctorDTO.Speciality);

            if (foundSpec == null) return BadRequest();

            var newDoctor = new DoctorDatabase(doctorDTO);
            _context.Doctors.Add(newDoctor);
            await _context.SaveChangesAsync();

            var token = _tokenManager.CreateTokenByName(newDoctor.Id);

            return Ok(new TokenResponseModel(token));
        }

        /// <summary>
        /// Log in to the system
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginCredentialsModel loginData)
        {
            if (!ModelState.IsValid) return BadRequest();

            var foundUser = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == loginData.Email);

            if (foundUser == null || !Crypto.VerifyHashedPassword(foundUser.Password, loginData.Password))
            {
                return BadRequest();
            }

            foundUser.Password = "";

            var token = _tokenManager.CreateTokenByName(foundUser.Id);

            return Ok(new TokenResponseModel(token));
        }

        /// <summary>
        /// Log out system user
        /// </summary>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> PostLogout()
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var tokenInBlacklist = new BlacklistToken(token);
            _context.BlacklistTokens.Add(tokenInBlacklist);
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Get user profile
        /// </summary>
        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            loginnedDoctor.Password = "";
            var doctor = new DoctorModel(loginnedDoctor);

            return Ok(doctor);
        }

        /// <summary>
        /// Edit user profile
        /// </summary>
        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromBody] DoctorEditModel newDoctor)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return Unauthorized();

            loginnedDoctor.Email = newDoctor.Email;
            loginnedDoctor.Name = newDoctor.Name;
            loginnedDoctor.Birthday = newDoctor.Birthday;
            loginnedDoctor.Gender = newDoctor.Gender;
            loginnedDoctor.Phone = newDoctor.Phone;

            await _context.SaveChangesAsync();

            loginnedDoctor.Password = "";

            return Ok();
        }
    }
}
