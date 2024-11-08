namespace Medical_Information_System_API.Classes
{
    public class ChildParentIcd
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }

        public ChildParentIcd() { }
    }
}
