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
        /// <response code="200">Doctor was registered</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(TokenResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost("register")]
        public async Task<IActionResult> PostRegister([FromBody] DoctorRegisterModel doctorDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var doctor = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == doctorDTO.Email);

            if (doctor != null) return BadRequest(new ResponseModel("Error", "This email is already used"));

            var foundSpec = await _context.SpecialitiesList.FirstOrDefaultAsync(u => u.Id == doctorDTO.Speciality);

            if (foundSpec == null) return BadRequest(new ResponseModel("Error", "This speciality doesn't exits"));

            var newDoctor = new DoctorDatabase(doctorDTO);
            _context.Doctors.Add(newDoctor);
            await _context.SaveChangesAsync();

            var token = _tokenManager.CreateTokenByName(newDoctor.Id);

            return Ok(new TokenResponseModel(token));
        }


        /// <summary>
        /// Log in to the system
        /// </summary>
        /// <response code="200">Doctor was loginned</response>
        /// <response code="400">Invalid arguments</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(TokenResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginCredentialsModel loginData)
        {
            if (!ModelState.IsValid) return BadRequest();

            var foundUser = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == loginData.Email);

            if (foundUser == null || !Crypto.VerifyHashedPassword(foundUser.Password, loginData.Password))
            {
                return BadRequest(new ResponseModel("Error", "Invalid account details"));
            }

            foundUser.Password = "";

            var token = _tokenManager.CreateTokenByName(foundUser.Id);

            return Ok(new TokenResponseModel(token));
        }


        /// <summary>
        /// Log out system user
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="401">Invalid arguments</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> PostLogout()
        {
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (token == null || !_context.CheckToken(token)) return Unauthorized();

            var tokenInBlacklist = new BlacklistToken(token);
            _context.BlacklistTokens.Add(tokenInBlacklist);
            await _context.SaveChangesAsync();

            return Ok(new ResponseModel("Success", "Doctor log outed from system"));
        }


        /// <summary>
        /// Get user profile
        /// </summary>
        /// <response code="200">Doctor was loginned</response>
        /// <response code="401">Invalid arguments</response>
        /// <response code="404">Invalid arguments</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(DoctorModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return NotFound();

            loginnedDoctor.Password = "";
            var doctor = new DoctorModel(loginnedDoctor);

            return Ok(doctor);
        }


        /// <summary>
        /// Edit user profile
        /// </summary>
        /// <response code="200">Doctor was loginned</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> EditProfile([FromBody] DoctorEditModel newDoctor)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = HttpContext.GetTokenAsync("access_token").Result;

            if (userId == null || token == null || !_context.CheckToken(token)) return Unauthorized();

            var loginnedDoctor = await _context.Doctors.FindAsync(new Guid(userId));

            if (loginnedDoctor == null) return NotFound();

            loginnedDoctor.Email = newDoctor.Email;
            loginnedDoctor.Name = newDoctor.Name;
            loginnedDoctor.Birthday = newDoctor.Birthday;
            loginnedDoctor.Gender = newDoctor.Gender;
            loginnedDoctor.Phone = newDoctor.Phone;

            await _context.SaveChangesAsync();

            loginnedDoctor.Password = "";

            return Ok(new ResponseModel("Success", "Doctor successfully edited"));
        }
    }
}
