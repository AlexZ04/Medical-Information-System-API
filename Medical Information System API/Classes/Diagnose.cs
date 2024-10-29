using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Diagnose
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public Icd10Record Record { get; set; }
        public string Description { get; set; }
        public DiagnosisType Type { get; set; }

        public Diagnose(DiagnosisCreateModel model, Icd10Record record)
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
            Record = record;
            Description = model.Description;
            Type = model.Type;
        }

        public Diagnose() { }
    }
}
