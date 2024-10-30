using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class InspectionPreviewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [AllowNull]
        public Guid? PreviousId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Conclusion Conclusion { get; set; }
        [Required]
        public Guid DoctorId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Doctor field must be at least 1 character.")]
        public string Doctor { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Patient field must be at least 1 character.")]
        public string Patient { get; set; }
        [Required]
        public DiagnosisModel Diagnosis { get; set; }
        public bool HasChain { get; set; }
        public bool HasNested { get; set; }

        public InspectionPreviewModel(Inspection insp, bool hasChain, bool hasNested)
        {
            Id = insp.Id;
            CreateTime = insp.CreateTime;
            PreviousId = insp.PreviousInspectionId;
            Date = insp.Date;
            Conclusion = insp.Conclusion;
            DoctorId = insp.Doctor.Id;
            Doctor = insp.Doctor.Name;
            PatientId = insp.Patient.Id;
            Patient = insp.Patient.Name;

            foreach (var diag in insp.Diagnoses)
            {
                if (diag.Type == DiagnosisType.Main)
                {
                    Diagnosis = new DiagnosisModel(diag);
                    break;
                }
            }

            HasChain = hasChain;
            HasNested = hasNested;
        }
    }
}
