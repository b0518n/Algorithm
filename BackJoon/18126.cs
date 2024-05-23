StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = null;

int a = 0;
int b = 0;
int c = 0;

Node[] nodes = new Node[n + 1];
int[,] costs = new int[n + 1, n + 1];
int[] visited = new int[n + 1];

long cost = 0;
long result = 0;

for (int i = 1; i < n + 1; i++)
{
    nodes[i] = new Node(i);
}

Tree tree = new Tree(nodes[1]);
visited[1] = 1;

for (int i = 0; i < n - 1; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    nodes[a].AddChild(nodes[b]);
    nodes[b].AddChild(nodes[a]);
    costs[a, b] = c;
    costs[b, a] = c;
}

SearchDestination(tree.root);
sw.WriteLine(result);
sw.Flush();
sw.Close();

void SearchDestination(Node node)
{
    result = Math.Max(result, cost);

    foreach (Node child in node.childs)
    {
        if (visited[child.number] == 1)
        {
            continue;
        }

        visited[child.number] = 1;
        cost += costs[node.number, child.number];
        SearchDestination(child);
        cost -= costs[node.number, child.number];
        visited[child.number] = 0;
    }
}

class Tree
{
    public Node root;

    public Tree(Node node)
    {
        this.root = node;
    }
}

public class Node
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
        childs.Add(node);
    }
}