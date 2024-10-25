using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    // DTO при PUT-запросе редактирования пользователя
    public class DoctorEditModel
    {
        [Required]
        [MinLength(1, ErrorMessage = "Email field must contain at least 1 character.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Invalid length of name field.")]
        public string Name { get; set; }
        [AllowNull]
        public DateTime Birthday { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [AllowNull]
        [Phone]
        public string Phone { get; set; }
    }
}
