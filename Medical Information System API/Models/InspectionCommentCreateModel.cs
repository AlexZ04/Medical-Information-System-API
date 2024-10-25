using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class InspectionCommentCreateModel
    {
        [Required]
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Invalid content field length.")]
        public string Context { get; set; }
    }
}
