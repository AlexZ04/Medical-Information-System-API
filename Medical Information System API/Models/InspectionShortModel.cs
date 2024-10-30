using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class InspectionShortModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DiagnosisModel Diagnosis { get; set; }

        public InspectionShortModel(Inspection insp)
        {
            Id = insp.Id;
            CreateTime = insp.CreateTime;
            Date = insp.Date;

            foreach (var diag in insp.Diagnoses)
            {
                if (diag.Type == DiagnosisType.Main)
                {
                    Diagnosis = new DiagnosisModel(diag);
                    break;
                }
            }

        }
    }
}
