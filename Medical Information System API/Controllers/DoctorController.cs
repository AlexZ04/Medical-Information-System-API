using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Data;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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
        //protected ApiResponse _response;
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

            var token = _tokenManager.CreateTokenByName(doctorDTO.Name);

            return Ok(new TokenResponseModel(token));
        }

        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginCredentialsModel loginData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var foundUser = await _context.Doctors.FindAsync(loginData.Email);

            if (foundUser == null || !Crypto.VerifyHashedPassword(foundUser.Password, loginData.Password))
            {
                return BadRequest();
            }

            foundUser.Password = "";

            var token = _tokenManager.CreateTokenByName(foundUser.Name);

            return Ok(new TokenResponseModel(token));
        }
    }
}
