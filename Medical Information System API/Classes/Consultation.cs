using Medical_Information_System_API.Models;

namespace Medical_Information_System_API.Classes
{
    public class Consultation
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid InspectionId { get; set; }
        public SpecialityModel Speciality { get; set; }
        public List<Comment> Comments { get; set; }
        public Guid AuthorId { get; set; }

        public Consultation()
        {
            Comments = new List<Comment>();
        }

        public Consultation(SpecialityModel speciality, Guid inspectionId, Comment comment, Guid author)
        {
            Id = Guid.NewGuid();
            InspectionId = inspectionId;
            CreateTime = DateTime.Now.ToUniversalTime();
            Speciality = speciality;
            Comments = new List<Comment> { comment };
            AuthorId = author;
        }
    }
}
