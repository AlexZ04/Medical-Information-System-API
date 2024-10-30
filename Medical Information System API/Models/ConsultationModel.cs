using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class ConsultationModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public Guid InspectionId { get; set; }
        public SpecialityModel Speciality { get; set; }
        [AllowNull]
        public List<CommentModel> Comments { get; set; }

        public ConsultationModel(Consultation consultation)
        {
            Id = consultation.Id;
            CreateTime = consultation.CreateTime;
            InspectionId = consultation.InspectionId;
            Speciality = consultation.Speciality;

            Comments = new List<CommentModel>();

            foreach (var comment in consultation.Comments)
            {
                Comments.Add(new CommentModel(comment));
            }
        }
    }
}
