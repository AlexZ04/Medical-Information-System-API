using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class DoctorModel
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        [MinLength(1, ErrorMessage = "Name field must contain at least one character.")]
        public string Name { get; set; }
        [AllowNull]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        [MinLength(1, ErrorMessage = "Email field must contain at least 1 character.")]
        [EmailAddress]
        public string Email { get; set; }
        [AllowNull]
        [Phone]
        public string Phone { get; set; }
    }
}
