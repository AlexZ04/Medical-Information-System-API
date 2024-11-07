using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class DoctorModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Name field must contain at least one character.")]
        public string Name { get; set; }
        [AllowNull]
        public DateTime? Birthday { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Email field must contain at least 1 character.")]
        [EmailAddress]
        public string Email { get; set; }
        [AllowNull]
        [Phone]
        [RegularExpression("^\\+7\\s\\(\\d{3}\\)\\s\\d{3}-\\d{2}-\\d{2}$", ErrorMessage = "Phone field must match mask: +7 (xxx) xxx-xx-xx")]
        public string? Phone { get; set; }
        public Guid Speciality { get; set; }

        public DoctorModel(DoctorDatabase model)
        {
            Id = model.Id;
            CreateTime = model.CreateTime;
            Name = model.Name;
            Birthday = model.Birthday;
            Gender = model.Gender;
            Email = model.Email;
            Phone = model.Phone;
            Speciality = model.Speciality;
        }
    }
}
