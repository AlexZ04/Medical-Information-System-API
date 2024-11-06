using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class IcdRootsReportFiltersModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [AllowNull]
        public List<string> IcdRoots { get; set; }

        public IcdRootsReportFiltersModel(DateTime start, DateTime end, List<string> roots)
        {
            Start = start; 
            End = end;
            IcdRoots = roots;
        }
    }
}
