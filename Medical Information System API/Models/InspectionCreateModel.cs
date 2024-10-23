using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class InspectionCreateModel
    {
        public DateTime Date {  get; set; }
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Invalid anamnesis field length.")]
        public string Anamnesis { get; set; }
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Invalid complaints field length.")]
        public string Complaints { get; set; }
        [StringLength(5000, MinimumLength = 1, ErrorMessage = "Invalid treatment field length.")]
        public string Treatment { get; set; }
        public Conclusion Conclusion { get; set; }
        [AllowNull]
        public DateTime NextVisitDate { get; set; }
        [AllowNull]
        public DateTime DeathDate { get; set; }
        [AllowNull]
        public Guid PreviousInspectionId {  get; set; }
        
        // диагноз и консультация
    }
}
