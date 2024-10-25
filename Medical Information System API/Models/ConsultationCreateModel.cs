using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class ConsultationCreateModel
    {
        [Required]
        public Guid SpecialityId { get; set; }
        [Required]
        public InspectionCommentCreateModel Comment { get; set; }
    }
}
