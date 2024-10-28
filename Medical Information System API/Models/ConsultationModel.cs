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
    }
}
