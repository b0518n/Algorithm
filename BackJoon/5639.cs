StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int key = -1;
string input = null;

List<int> preOrderTreval = new List<int>();

while (true)
{
    input = Console.ReadLine();
    if (input == null)
    {
        break;
    }
    else
    {
        key = int.Parse(input);
        preOrderTreval.Add(key);
    }
}

BTreeNode root = new BTreeNode(preOrderTreval[0]);

int value = 0;
BTreeNode node = null;

for (int i = 1; i < preOrderTreval.Count; i++)
{
    value = preOrderTreval[i];
    node = root;

    while (true)
    {
        if (node.number > value)
        {
            if (node.leftChildNode == null)
            {
                node.leftChildNode = new BTreeNode(value);
                break;
            }
            else
            {
                node = node.leftChildNode;
            }
        }
        else
        {
            if (node.rightChildNode == null)
            {
                node.rightChildNode = new BTreeNode(value);
                break;
            }
            else
            {
                node = node.rightChildNode;
            }
        }
    }
}

Print(root);

void Print(BTreeNode node)
{
    PostOrderTraval(node);
    sw.Flush();
    sw.Close();
}

void PostOrderTraval(BTreeNode node)
{
    if (node.leftChildNode != null && node.rightChildNode != null)
    {
        PostOrderTraval(node.leftChildNode);
        PostOrderTraval(node.rightChildNode);
        sw.WriteLine(node.number);
    }
    else if (node.leftChildNode != null && node.rightChildNode == null)
    {
        PostOrderTraval(node.leftChildNode);
        sw.WriteLine(node.number);
    }
    else if (node.leftChildNode == null && node.rightChildNode != null)
    {
        PostOrderTraval(node.rightChildNode);
        sw.WriteLine(node.number);
    }
    else
    {
        sw.WriteLine(node.number);
    }
}

class BTreeNode
{
    public int number;
    public BTreeNode leftChildNode;
    public BTreeNode rightChildNode;

    public BTreeNode(int number)
    {
        this.number = number;
        leftChildNode = null;
        rightChildNode = null;
    }
}