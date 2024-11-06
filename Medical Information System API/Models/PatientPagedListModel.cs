using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class PatientPagedListModel
    {
        [AllowNull]
        public List<PatientModel>? Patients { get; set; }
        public PageInfoModel Pagination { get; set; }

        public PatientPagedListModel(List<PatientModel> patients, PageInfoModel pagination) { 
            Patients = patients;
            Pagination = pagination;
        }
    }
}
