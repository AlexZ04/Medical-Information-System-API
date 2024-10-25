using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class DiagnosisCreateModel
    {
        [Required]
        public Guid IcdDiagnosisId { get; set; }
        [StringLength(5000, ErrorMessage = "Invalid description field length")]
        public string Description { get; set; }
        [Required]
        public DiagnosisType Type { get; set; }
    }
}
