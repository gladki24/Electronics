namespace Electronics.Graph.Calculator
{
    /// <summary>
    /// Class representing abstract mathematical graph
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Root node of graph
        /// </summary>
        public Node Root { get; private set; }

        /// <summary>
        /// Default constructor of graph
        /// </summary>
        /// <param name="root">Root node of graph</param>
        public Graph(Node root)
        {
            Root = root;
        }

        /// <summary>
        /// Find node with specified name
        /// </summary>
        /// <param name="name">Name of node</param>
        /// <returns>Node if find else null</returns>
        public Node? FindOrDefault(string name) => Root.FindChildOrDefault(name);
        
        /// <summary>
        /// Find node with specified name or throw exception
        /// </summary>
        /// <param name="name">Name of node</param>
        /// <returns>Node if find else throw exception</returns>
        public Node Find(string name) => Root.Find(name);

        /// <summary>
        /// Find trace from root to specified node by name
        /// </summary>
        /// <param name="name">Name of target node</param>
        /// <param name="stack">Passed by reference stack where will be stored trace</param>
        public void Trace(string name, Stack<string> stack) => Root.Trace(name, stack);
    }
}
