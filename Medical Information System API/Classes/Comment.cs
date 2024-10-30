using Medical_Information_System_API.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        [AllowNull]
        public DateTime? ModifiedDate { get; set; }
        public string Content { get; set; }
        public DoctorDatabase Author { get; set; }
        [AllowNull]
        public Guid? ParentId { get; set; }

        public Comment() { }

        public Comment(InspectionCommentCreateModel comment, DoctorDatabase doctor)
        {
            Author = doctor;
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now.ToUniversalTime();
            Content = comment.Context;
        }
    }
}
