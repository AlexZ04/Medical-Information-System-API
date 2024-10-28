using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Medical_Information_System_API.Classes
{
    public class Comment
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        [AllowNull]
        public DateTime ModifiedDate { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        [AllowNull]
        public Guid ParentId { get; set; }
    }
}
