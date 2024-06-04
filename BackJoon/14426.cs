using System.Text;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

Tree tree = new Tree(new Node(string.Empty));
InputStr_Fun(n);
int result = GetResult_Fun(m);
OutPutResult_Fun(result);

void InputStr_Fun(int _cnt)
{
    string str = string.Empty;
    StringBuilder sb = new StringBuilder();
    Node parentNode = null;
    Node childNode = null;

    for (int i = 0; i < _cnt; i++)
    {
        sb.Clear();
        parentNode = tree.root;
        str = sr.ReadLine();
        for (int j = 0; j < str.Length; j++)
        {
            sb.Append(str[j]);
            if (parentNode.childNodes.Count == 0)
            {
                childNode = new Node(sb.ToString());
                parentNode.AddChild(childNode);
                parentNode = childNode;
            }
            else
            {
                bool hasPrefix = false;

                foreach (Node child in parentNode.childNodes)
                {
                    if (child.str == sb.ToString())
                    {
                        parentNode = child;
                        hasPrefix = true;
                        break;
                    }
                }

                if (!hasPrefix)
                {
                    childNode = new Node(sb.ToString());
                    parentNode.AddChild(childNode);
                    parentNode = childNode;
                }
            }

        }
    }
}
int GetResult_Fun(int _cnt)
{
    int retValue = 0;

    for (int i = 0; i < _cnt; i++)
    {
        if (hasPrefixString_Fun(sr.ReadLine()))
        {
            retValue++;
        }
    }

    return retValue;
}
bool hasPrefixString_Fun(string _str)
{
    StringBuilder sb = new StringBuilder();
    Node node = tree.root;
    bool hasString = false;
    for (int i = 0; i < _str.Length; i++)
    {
        hasString = false;
        sb.Append(_str[i]);

        foreach (Node child in node.childNodes)
        {
            if (child.str == sb.ToString())
            {
                hasString = true;
                node = child;
                break;
            }
        }

        if (!hasString)
        {
            return false;
        }
    }

    return true;
}
void OutPutResult_Fun(int _result)
{
    sw.WriteLine(_result);
    sw.Flush();
    sw.Close();
}

class Tree
{
    public Node root;

    public Tree(Node _root)
    {
        this.root = _root;
    }
}

class Node
{
    public string str;
    public List<Node> childNodes;

    public Node(string _str)
    {
        this.str = _str;
        childNodes = new List<Node>();
    }

    public void AddChild(Node _node)
    {
        childNodes.Add(_node);
    }
}