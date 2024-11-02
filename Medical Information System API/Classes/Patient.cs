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
        public Conclusion? HealthStatus { get; set; }

        public Patient()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
        }

        public Patient(PatientModel model)
        {
            Id = model.Id;
            Name = model.Name;
            CreateTime = model.CreateTime;
            Birthday = model.Birthday;
            Gender = model.Gender;
        }

        public Patient(PatientCreateModel patient)
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
            Name = patient.Name;
            Birthday = patient.Birthday;
            Gender = patient.Gender;
        }
    }
}
