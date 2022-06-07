using Electronics.Graph.Calculator;

var root = new Node("A");

var graph = new Graph(root);

root.AddChild("B");
root.AddChild("C");
var cNode = graph.Find("C");
cNode.AddChild("I");
cNode.AddChild("J");

root.AddChild("D");

var dNode = graph.Find("D");
dNode.AddChild("E");
dNode.AddChild("F");

var fNode = graph.Find("F");
fNode.AddChild("G");
fNode.AddChild("H");

var hNode = graph.Find("H");
hNode.AddChild(root);

var stack = new Stack<string>();
root.FindCycle(stack);

foreach (var name in stack.Reverse())
{
    Console.Write($"{name} ");
}
