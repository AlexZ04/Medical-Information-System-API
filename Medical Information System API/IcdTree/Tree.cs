using Medical_Information_System_API.Classes;

namespace Medical_Information_System_API.IcdTree
{
    public class Tree
    {
        public Node Root { get; set; }

        public List<Icd10Record> GetChildren(string value)
        {
            var children = new List<Icd10Record>();

            var currentNode = Root;
            var currentStr = "";
            bool flag = false;
            bool appendChild = true;

            foreach (char c in value)
            {
                flag = false;
                currentStr += c;

                foreach (Node node in currentNode.Children)
                {
                    if (node.Value == currentStr)
                    {
                        currentNode = node;
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    appendChild = false;
                    break;
                }
            }

            if (appendChild) {
                var prevLevel = new List<Node>() { currentNode };
                var nextLevel = new List<Node>();

                while (prevLevel.Count > 0)
                {
                    foreach (var node in prevLevel)
                    {
                        nextLevel.AddRange(node.Children);
                        children.AddRange(node.Records);
                    }

                    prevLevel = new List<Node>(nextLevel);
                    nextLevel = new List<Node>();
                }
            }

            return children;
        }
    }
}
