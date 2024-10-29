using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class InspectionPreviewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid CreateTime { get; set; }
        public Guid PreviousId { get; set; }
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
    }
}
