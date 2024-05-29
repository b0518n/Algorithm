StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

List<Tree> treeList = new List<Tree>();
for (int i = 0; i < n; i++)
{
    treeList.Add(new Tree(i, 0));
}

int p = 0;
int c = 0;

for (int i = 0; i < n - 1; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    p = input[0];
    c = input[1];

    treeList[p].childTreeList.Add(treeList[c]);
}

BFS();

int[] values = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

for (int i = 0; i < n; i++)
{
    if (values[i] == k)
    {
        sw.WriteLine(treeList[i].depth);
    }
}

sw.Flush();
sw.Close();


void BFS()
{
    Queue<Tree> q = new Queue<Tree>();
    q.Enqueue(treeList[0]);

    Tree temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        foreach (Tree child in temp.childTreeList)
        {
            child.depth = temp.depth + 1;
            q.Enqueue(child);
        }
    }
}

class Tree
{
    public int number;
    public List<Tree> childTreeList;
    public int depth;

    public Tree(int number, int depth)
    {
        this.number = number;
        this.childTreeList = new List<Tree>();
        this.depth = depth;
    }
}