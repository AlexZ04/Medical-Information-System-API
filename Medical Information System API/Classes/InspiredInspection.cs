namespace Medical_Information_System_API.Classes
{
    public class InspiredInspection
    {
        public Guid Id { get; set; }
        public Inspection Inspection { get; set; }
        public DateTime AddedTime { get; set; }
        public bool SendedEmail { get; set; }

        public InspiredInspection(Inspection inspection)
        {
            Id = Guid.NewGuid();
            Inspection = inspection;
            AddedTime = DateTime.Now.ToUniversalTime();
            SendedEmail = false;
        }

        public InspiredInspection()
        {
            Id = new Guid();
            AddedTime = DateTime.Now.ToUniversalTime();
        }
    }
}
