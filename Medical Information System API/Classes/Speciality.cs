using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Classes
{
    public class Speciality
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name field should have at least 1 symbol.")]
        public string Name { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }

        public Speciality(string name)
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
            Name = name;
        }

        public Speciality(SpecialityModel speciality) 
        {
            Id = speciality.Id;
            CreateTime = speciality.CreateTime;
            Name = speciality.Name;
        }
    }
}
