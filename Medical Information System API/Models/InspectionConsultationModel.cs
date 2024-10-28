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
    }
}
