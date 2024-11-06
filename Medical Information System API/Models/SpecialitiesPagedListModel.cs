using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class SpecialitiesPagedListModel
    {
        [AllowNull]
        public List<SpecialityModel>? Specialities { get; set; }
        public PageInfoModel Pagination { get; set; }

        public SpecialitiesPagedListModel(List<SpecialityModel> specialities, PageInfoModel pagination)
        {
            Specialities = specialities;
            Pagination = pagination;
        }
    }
}
