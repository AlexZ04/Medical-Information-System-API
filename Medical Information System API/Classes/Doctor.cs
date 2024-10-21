using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Doctor
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid Speciality { get; set; }
    }
}
