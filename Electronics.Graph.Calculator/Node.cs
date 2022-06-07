namespace Electronics.Graph.Calculator
{
    public class Node
    {
        public string Name { get; }
        public IList<Node> Nodes { get; }

        public Node(string name)
        {
            Name = name;
            Nodes = new List<Node>();
        }

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

        public Node FindChild(string name)
        {
            var node = FindChildOrDefault(name);
            
            if (node == null)
            {
                throw new Exception($"Child node with name {name} not found!");
            }

            return node;
        }

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

        public Node Find(string name)
        {
            var node = FindOrDefault(name);

            if (node == null)
            {
                throw new Exception($"Node with name {name} not found!");
            }

            return node;
        }

        public void AddChild(string name)
        {
            var node = FindChildOrDefault(name);

            if (node != null)
            {
                throw new Exception($"Node with name: {name} already exist!");
            }

            Nodes.Add(new Node(name));
        }

        public void AddChild(Node node)
        {
            Nodes.Add(node);
        }

        public void RemoveChild(string name)
        {
            var node = FindChild(name);
            Nodes.Remove(node);
        }

        public void RemoveChild(Node node)
            => Nodes.Remove(node);

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