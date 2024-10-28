using System.ComponentModel.DataAnnotations;

namespace Medical_Information_System_API.Models
{
    public class CommentCreateModel
    {
        [StringLength(1000, MinimumLength = 1, ErrorMessage = "Invalid length of content field.")]
        public string Content { get; set; }
        public Guid ParentId { get; set; }
    }
}
