namespace Electronics.Graph.Calculator
{
    public class Graph
    {
        public Node Root { get; private set; }

        public Graph(Node root)
        {
            Root = root;
        }

        public Node? FindOrDefault(string name) => Root.FindChildOrDefault(name);
        public Node Find(string name) => Root.Find(name);

        public void Trace(string name, Stack<string> stack) => Root.Trace(name, stack);
    }
}
