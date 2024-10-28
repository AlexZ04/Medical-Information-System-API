using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Inspection
    {   
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime Date { get; set; }
        public string Anamnesis { get; set; }
        public string Complaints { get; set; }
        public string Treatment { get; set; }
        public Conclusion Conclusion { get; set; }
        public DateTime NextVisitDate { get; set; }
        public DateTime DeathDate { get; set; }
        public Guid BaseInspectionId { get; set; }
        public Guid PreviousInspectionId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public List<DiagnosisModel> Diagnoses { get; set; }
        public List<Consultation> Consultations { get; set; }

        public Inspection()
        {
            Diagnoses = new List<DiagnosisModel>();
            Consultations = new List<Consultation>();
        }
    }
}
