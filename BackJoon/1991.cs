StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine()); // 노드의 개수
string[] input = null;

string parentNode = string.Empty;
string leftNode = string.Empty;
string rightNode = string.Empty;

List<List<string[]>> graph = new List<List<string[]>>();
for (int i = 0; i < n; i++)
{
    graph.Add(new List<string[]>());
}

for (int i = 0; i < n; i++)
{
    input = Console.ReadLine().Split();
    parentNode = input[0];
    leftNode = input[1];
    rightNode = input[2];

    if (leftNode == "." && rightNode != ".")
    {
        graph[char.Parse(parentNode) - 65].Add(new string[2] { rightNode, "Right" });
    }
    else if (leftNode != "." && rightNode == ".")
    {
        graph[char.Parse(parentNode) - 65].Add(new string[2] { leftNode, "Left" });
    }
    else if (leftNode != "." && rightNode != ".")
    {
        graph[char.Parse(parentNode) - 65].Add(new string[2] { leftNode, "Left" });
        graph[char.Parse(parentNode) - 65].Add(new string[2] { rightNode, "Right" });
    }
}

BTreeNode root = new BTreeNode("A");
AddChildNode(root);

Print(root);
sw.Flush();
sw.Close();

void AddChildNode(BTreeNode node)
{
    foreach (string[] temp in graph[char.Parse(node.name) - 65])
    {
        if (temp[1] == "Left")
        {
            node.leftChildNode = new BTreeNode(temp[0]);
            AddChildNode(node.leftChildNode);
        }
        else if (temp[1] == "Right")
        {
            node.rightChildNode = new BTreeNode(temp[0]);
            AddChildNode(node.rightChildNode);
        }

    }
}

void Print(BTreeNode node)
{
    PreOrderTravel(node);
    sw.WriteLine();
    InOrderTravel(node);
    sw.WriteLine();
    PostOrderTravel(node);
}

void PreOrderTravel(BTreeNode node)
{
    sw.Write(node.name);
    if (node.leftChildNode != null)
    {
        PreOrderTravel(node.leftChildNode);
    }

    if (node.rightChildNode != null)
    {
        PreOrderTravel(node.rightChildNode);
    }
}

void InOrderTravel(BTreeNode node)
{
    if (node.leftChildNode != null && node.rightChildNode != null)
    {
        InOrderTravel(node.leftChildNode);
        sw.Write(node.name);
        InOrderTravel(node.rightChildNode);
    }
    else if (node.leftChildNode != null && node.rightChildNode == null)
    {
        InOrderTravel(node.leftChildNode);
        sw.Write(node.name);
    }
    else if (node.leftChildNode == null && node.rightChildNode != null)
    {
        sw.Write(node.name);
        InOrderTravel(node.rightChildNode);
    }
    else
    {
        sw.Write(node.name);
    }
}

void PostOrderTravel(BTreeNode node)
{
    if (node.leftChildNode != null && node.rightChildNode != null)
    {
        PostOrderTravel(node.leftChildNode);
        PostOrderTravel(node.rightChildNode);
        sw.Write(node.name);
    }
    else if (node.leftChildNode != null && node.rightChildNode == null)
    {
        PostOrderTravel(node.leftChildNode);
        sw.Write(node.name);
    }
    else if (node.leftChildNode == null && node.rightChildNode != null)
    {
        PostOrderTravel(node.rightChildNode);
        sw.Write(node.name);
    }
    else
    {
        sw.Write(node.name);
    }
}
        }

        class BTreeNode
{
    public string name;
    public BTreeNode leftChildNode;
    public BTreeNode rightChildNode;

    public BTreeNode(string name)
    {
        this.name = name;
        leftChildNode = null;
        rightChildNode = null;
    }

    public void AddLeftChild(string name)
    {
        leftChildNode = new BTreeNode(name);
    }

    public void AddRightChild(string name)
    {
        rightChildNode = new BTreeNode(name);
    }
}