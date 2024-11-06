using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class Icd10SearchModel
    {
        [AllowNull]
        public List<Icd10RecordModel>? Records { get; set; }
        public PageInfoModel Pagination { get; set; }

        public Icd10SearchModel(List<Icd10RecordModel> list, PageInfoModel pagination)
        {
            Records = list;
            Pagination = pagination;
        }
    }
}
