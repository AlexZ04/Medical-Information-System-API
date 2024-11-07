using Medical_Information_System_API.Classes;

namespace Medical_Information_System_API.IcdTree
{
    public class Node
    {
        public string Value { get; set; }
        public List<Node> Children { get; set; }
        public List<Icd10Record> Records { get; set; }

        public Node(string value)
        {
            Value = value;
            Children = new List<Node>();
            Records = new List<Icd10Record>();
        }
    }
}
