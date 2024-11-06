using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class IcdRootsReportModel
    {
        public IcdRootsReportFiltersModel Filters { get; set; }
        [AllowNull]
        public List<IcdRootsReportRecordModel> Records { get; set; }
        [AllowNull]
        public Dictionary<string, int> SummaryByRoot { get; set; }

        public IcdRootsReportModel(IcdRootsReportFiltersModel filters, List<IcdRootsReportRecordModel> records,
            Dictionary<string, int> summary)
        {
            Filters = filters;
            Records = records;
            SummaryByRoot = summary;
        }
    }
}
