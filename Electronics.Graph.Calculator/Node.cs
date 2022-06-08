namespace Electronics.Graph.Calculator
{
    /// <summary>
    /// Node of graphs
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Name to identify node
        /// </summary>
        public string Name { get; }

        // TODO may be change to Dictionary
        /// <summary>
        /// Child nodes
        /// </summary>
        public IList<Node> Nodes { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Name of the node to identify</param>
        public Node(string name)
        {
            Name = name;
            Nodes = new List<Node>();
        }

        /// <summary>
        /// Find one of child node
        /// </summary>
        /// <param name="name">Name of child to identify child node</param>
        /// <returns>Node or null if cannot find</returns>
        public Node? FindChildOrDefault(string name)
        {
            foreach (var node in Nodes)
            {
                if (node.Name == name)
                {
                    return node;
                }
            }

            return null;
        }

        /// <summary>
        /// Find one of child node
        /// </summary>
        /// <param name="name">Name of child to identify child node</param>
        /// <returns>Node or throw exception if cannot find</returns>
        /// <exception cref="Exception"></exception>
        public Node FindChild(string name)
        {
            var node = FindChildOrDefault(name);
            
            if (node == null)
            {
                throw new Exception($"Child node with name {name} not found!");
            }

            return node;
        }

        /// <summary>
        /// Find node in descendants
        /// </summary>
        /// <param name="name">Name of node to find</param>
        /// <returns>Node or null if cannot find</returns>
        public Node? FindOrDefault(string name)
        {
            foreach (var node in Nodes)
            {
                if (node.Name == name)
                {
                    return node;
                }

                var childNode = node.FindOrDefault(name);

                if (childNode != null)
                {
                    return childNode;
                }
            }

            return null;
        }

        /// <summary>
        /// Find node in descendants
        /// </summary>
        /// <param name="name">Name of node to find</param>
        /// <returns>Node or throw exception if cannot find</returns>
        /// <exception cref="Exception"></exception>
        public Node Find(string name)
        {
            var node = FindOrDefault(name);

            if (node == null)
            {
                throw new Exception($"Node with name {name} not found!");
            }

            return node;
        }

        /// <summary>
        /// Add node to child nodes by name
        /// </summary>
        /// <param name="name">Name of node to add</param>
        /// <exception cref="Exception"></exception>
        public void AddChild(string name)
        {
            var node = FindChildOrDefault(name);

            if (node != null)
            {
                throw new Exception($"Node with name: {name} already exist!");
            }

            Nodes.Add(new Node(name));
        }

        /// <summary>
        /// Add node to child nodes by node
        /// </summary>
        /// <param name="node">Node to add</param>
        public void AddChild(Node node)
        {
            Nodes.Add(node);
        }

        /// <summary>
        /// Remove node using name
        /// </summary>
        /// <param name="name">Name of node to remove</param>
        public void RemoveChild(string name)
        {
            var node = FindChild(name);
            Nodes.Remove(node);
        }

        /// <summary>
        /// Remove node using reference to node
        /// </summary>
        /// <param name="node">Node to remove</param>
        public void RemoveChild(Node node)
            => Nodes.Remove(node);

        /// <summary>
        /// Find trace to specified node by name
        /// </summary>
        /// <param name="name">Name of node</param>
        /// <param name="stack">Passed by reference stack where will be stored trace</param>
        /// <returns></returns>
        public bool Trace(string name, Stack<string> stack)
        {
            stack.Push(Name);

            foreach (var node in Nodes)
            {
                if (node.Name == name)
                {
                    stack.Push(node.Name);
                    return true;
                }

                var result = node.Trace(name, stack);

                if (result)
                {
                    return true;
                }
            }

            stack.Pop();
            return false;
        }
        
        /// <summary>
        /// Find any cycles in graph
        /// </summary>
        /// <param name="stack">Stack which stored trace</param>
        /// <returns></returns>
        public bool FindCycle(Stack<string> stack)
        {
            stack.Push(Name);

            foreach (var node in Nodes)
            {
                if (stack.Contains(node.Name))
                {
                    stack.Push(node.Name);
                    return true;
                }

                var result = node.FindCycle(stack);

                if (result)
                {
                    return true;
                }
            }

            stack.Pop();
            return false;
        }
    }
}