using Medical_Information_System_API.Classes;
using Medical_Information_System_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Validations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Medical_Information_System_API.Controllers
{
    [ApiController]
    [Route("api/doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly ILogger<DoctorController> _logger;
        //protected ApiResponse _response;
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        public DoctorController(ILogger<DoctorController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Get([FromBody] DoctorRegisterModel doctorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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
    }
}
