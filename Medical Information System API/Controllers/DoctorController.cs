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

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, doctorDTO.Name),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new (AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new TokenResponseModel(tokenHandler.WriteToken(token)));
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

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, foundUser.Name),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new TokenResponseModel(tokenHandler.WriteToken(token)));
        }
    }
}
