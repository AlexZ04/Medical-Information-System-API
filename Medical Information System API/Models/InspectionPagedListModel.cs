using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class InspectionPagedListModel
    {
        [AllowNull]
        public List<InspectionPreviewModel> Inspections { get; set; }
        public PageInfoModel Pagination { get; set; }

    }
}
