StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

Node[] nodes = new Node[n];
for (int i = 0; i < n; i++)
{
    nodes[i] = new Node(i);
}

Tree tree = new Tree(nodes[0]);

for (int i = 0; i < n - 1; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    nodes[input[0]].AddChild(nodes[input[1]]);
}

int[] apples = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
DFS(tree.root);
sw.Flush();
sw.Close();

void DFS(Node node)
{
    Stack<Info> stack = new Stack<Info>();
    stack.Push(new Info(node, 0));

    Info temp = null;
    Node _node = null;
    int _distacne = 0;

    int result = 0;

    if (apples[node.number] == 1)
    {
        result++;
    }

    while (stack.Count > 0)
    {
        temp = stack.Pop();
        _node = temp.node;
        _distacne = temp.distance;

        if (_distacne == k)
        {
            continue;
        }

        foreach (Node child in _node.childs)
        {
            if (apples[child.number] == 1)
            {
                result++;
            }

            stack.Push(new Info(child, _distacne + 1));
        }
    }

    sw.WriteLine(result);
}

class Tree
{
    public Node root;

    public Tree(Node root)
    {
        this.root = root;
    }
}
class Node
{
    public int number;
    public List<Node> childs;

    public Node(int number)
    {
        this.number = number;
        this.childs = new List<Node>();
    }

    public void AddChild(Node node)
    {
        this.childs.Add(node);
    }
}
class Info
{
    public Node node;
    public int distance;

    public Info(Node node, int distance)
    {
        this.node = node;
        this.distance = distance;
    }
}