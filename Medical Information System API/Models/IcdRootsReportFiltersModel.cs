using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class IcdRootsReportFiltersModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [AllowNull]
        public List<string>? IcdRoots { get; set; }
    }
}
