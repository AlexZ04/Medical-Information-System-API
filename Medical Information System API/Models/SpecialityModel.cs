using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class SpecialityModel
    {
        [MinLength(1, ErrorMessage = "Name field should have at least 1 symbol.")]
        public string Name { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }

        public SpecialityModel(string name)
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
            Name = name;
        }
    }
}
