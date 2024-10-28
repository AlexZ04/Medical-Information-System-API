using Medical_Information_System_API.Models;

namespace Medical_Information_System_API.Classes
{
    public class Consultation
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid InspectionId { get; set; }
        public Guid SpecialityId { get; set; }
        public List<Comment> Comments { get; set; }

        public Consultation()
        {
            Comments = new List<Comment>();
        }
    }
}
