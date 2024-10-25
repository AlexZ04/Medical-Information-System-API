using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class TokenResponseModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "Token length must contain at least 1 symbol")]
        public string Token { get; set; }

        public TokenResponseModel(string token)
        {
            Token = token;
        }
    }
}
