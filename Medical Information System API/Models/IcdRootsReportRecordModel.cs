using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class IcdRootsReportRecordModel
    {
        [AllowNull]
        public string? PatientName { get; set; }
        public DateTime PatientBirthdate { get; set; }
        public Gender Gender { get; set; }
        [AllowNull]
        public Dictionary<string, int> VisitByRoot { get; set; }
    }
}
