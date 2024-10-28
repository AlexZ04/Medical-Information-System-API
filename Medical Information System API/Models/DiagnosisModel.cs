using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class DiagnosisModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Invalid code field length.")]
        public string Code { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Invalid name field length.")]
        public string Name { get; set; }
        [AllowNull]
        public string Description { get; set; }
        [Required]
        public DiagnosisType Type { get; set; }
    }
}
