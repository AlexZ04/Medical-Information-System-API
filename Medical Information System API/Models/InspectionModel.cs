using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class InspectionModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public DateTime Date { get; set; }
        [AllowNull]
        public string Anamnesis { get; set; }
        [AllowNull]
        public string Complaints { get; set; }
        [AllowNull]
        public string Treatment { get; set; }
        public Conclusion Conclusion { get; set; }
        [AllowNull]
        public DateTime NextVisitDate { get; set; }
        [AllowNull]
        public DateTime DeathDate { get; set; }
        [AllowNull]
        public Guid BaseInspectionId { get; set; }
        [AllowNull]
        public Guid PreviousInspectionId { get; set; }
        public PatientModel Patient { get; set; }
        public DoctorModel Doctor { get; set; }
        [AllowNull]
        public List<DiagnosisModel> Diagnoses { get; set; }
        [AllowNull]
        public List<InspectionConsultationModel> Consultations { get; set; }
    }
}
