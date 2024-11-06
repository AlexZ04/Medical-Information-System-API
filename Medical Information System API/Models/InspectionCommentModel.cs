using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class InspectionCommentModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [AllowNull]
        public Guid? ParentId { get; set; }
        [AllowNull]
        public string? Content { get; set; }
        public DoctorModel Author { get; set; }
        public DateTime? ModifyTime { get; set; }

        public InspectionCommentModel(Comment com)
        {
            Id = com.Id;
            CreateTime = com.CreateTime;
            ParentId = com.ParentId;
            Content = com.Content;
            ModifyTime = com.ModifiedDate;

            Author = new DoctorModel(com.Author);
        }
    }
}
