using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class InspectionConsultationModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public Guid InspectionId { get; set; }
        public SpecialityModel Speciality { get; set; }
        public InspectionCommentModel RootComment { get; set; }
        public int CommentsNumber { get; set; }

        public InspectionConsultationModel(Consultation cons)
        {
            Id = cons.Id;
            CreateTime = cons.CreateTime;
            InspectionId = cons.InspectionId;
            Speciality = cons.Speciality;

            RootComment = new InspectionCommentModel(cons.Comments[0]);

            CommentsNumber = cons.Comments.Count;
        }
    }
}
