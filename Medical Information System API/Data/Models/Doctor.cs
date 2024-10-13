using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Medical_Information_System_API.Data.Models
{
    public class Doctor
    {

    }

    public class DoctorEditModel
    {
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Email field must contain at least one character.")]
        public string Email { get; set; }
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Invalid length of name field.")]
        public string Name { get; set; }
        [AllowNull]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        [AllowNull]
        public string Phone { get; set; }
    }

    public class DoctorModel
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Name field must contain at least one character.")]
        public string Name { get; set; }
        [AllowNull]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Email field must contain at least one character.")]
        public string Email { get; set; } // ???
        [AllowNull]
        public string Phone { get; set; } // ???
    }

    public class DoctorRegistrationModel {
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Invalid length of name field.")]
        public string Name { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 6, ErrorMessage = "Password must contain at least 6 characters.")]
        public string Password { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Email field must contain at least 1 character.")]
        public string Email { get; set; }
        [AllowNull]
        public string Birthday { get; set; }
        public Gender Gender { get; set; }
        [AllowNull]
        public string Phone { get; set; }
        public string Speciality { get; set; } // ???
    }
}
