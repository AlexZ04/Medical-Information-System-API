using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Patient
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public List<Inspection> Inspections { get; set; } 

        public Patient() { 
            Inspections = new List<Inspection>();
        }

        public Patient(PatientModel model)
        {
            Id = model.Id;
            Name = model.Name;
            CreateTime = model.CreateTime;
            Birthday = model.Birthday;
            Gender = model.Gender;
            Inspections = new List<Inspection>();
        }
    }
}
