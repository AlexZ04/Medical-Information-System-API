using Medical_Information_System_API.Classes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Models
{
    public class CommentModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        [AllowNull]
        public DateTime? ModifiedDate { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Invalid content field length.")]
        public string Content { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Invalid author field length.")]
        public string Author { get; set; }
        [AllowNull]
        public Guid? ParentId { get; set; }

        public CommentModel(Comment comment)
        {
            Id = comment.Id;
            CreateTime = comment.CreateTime;
            ModifiedDate = comment.ModifiedDate;
            Content = comment.Content;

            AuthorId = comment.Author.Id;
            Author = comment.Author.Name;

            ParentId = comment.ParentId;
        }
    }
}
