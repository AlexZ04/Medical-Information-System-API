using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class PatientCreateModel
    {
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Invalid name field length.")]
        public string Name { get; set; }
        [AllowNull]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
    }
}
