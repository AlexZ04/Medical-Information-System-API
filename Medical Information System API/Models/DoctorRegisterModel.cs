using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Medical_Information_System_API.Models
{
    // DTO при регистрации доктора
    public class DoctorRegisterModel
    {
        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Invalid length of name field.")]
        public string Name { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 characters.")]
        public string Password { get; set; }
        [MinLength(1, ErrorMessage = "Email field must contain at least 1 character.")]
        [EmailAddress]
        public string Email { get; set; }
        [AllowNull]
        public DateTime? Birthday { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [AllowNull]
        [Phone]
        [RegularExpression("^\\+7.\\(\\d{3}\\).\\d{3}-\\d{2}-\\d{2}$", ErrorMessage = "Phone field must match mask: +7 (xxx) xxx-xx-xx")]
        public string? Phone { get; set; }
        [Required]
        public Guid Speciality { get; set; }
    }
}
