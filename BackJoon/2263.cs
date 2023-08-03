StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] inOrderArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] postOrderArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

BTreeNode root = MakeTree(inOrderArr, postOrderArr, 0, inOrderArr.Length - 1, 0, postOrderArr.Length - 1);
Print(root);
sw.Flush();
sw.Close();

BTreeNode MakeTree(int[] inOrderArr, int[] postOrderArr, int iStart, int iEnd, int pStart, int pEnd)
{
    if (iStart > iEnd)
    {
        return null;
    }

    // postOrder의 해당 범위의 맨 끝의 인덱스가 중간 정점의 번호를 나타냄
    int rootNumber = postOrderArr[pEnd]; 
    int index = Array.IndexOf(inOrderArr, rootNumber);

    int leftTreeLength = index - iStart;
    int rightTreeLength = iEnd - index;

    BTreeNode root = new BTreeNode(rootNumber);
    root.leftChildNode = MakeTree(inOrderArr, postOrderArr, iStart, index - 1, pStart, pStart + leftTreeLength - 1);
    root.rightChildNode = MakeTree(inOrderArr, postOrderArr, index + 1, iEnd, pEnd - rightTreeLength, pEnd - 1);

    return root;
}

void Print(BTreeNode node)
{
    PreOrderTravel(node);
    sw.WriteLine();
}

void PreOrderTravel(BTreeNode node)
{
    if (node != null)
    {
        sw.Write(node.number + " ");
        if (node.leftChildNode != null)
        {
            PreOrderTravel(node.leftChildNode);
        }

        if (node.rightChildNode != null)
        {
            PreOrderTravel(node.rightChildNode);
        }
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