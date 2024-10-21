using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class LoginCredentialsModel
    {
        [MinLength(1, ErrorMessage = "Email field must contain at least 1 character.")]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(1, ErrorMessage = "Password field must contain at least 1 character.")]
        public string Password { get; set; }
    }
}
