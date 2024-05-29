// Inorder Treverse

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int k = int.Parse(sr.ReadLine());
int[] InorderTraResult = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
List<List<int>> resultList = new List<List<int>>();

if (k == 1)
{
    sw.WriteLine(InorderTraResult[0]);
}
else
{
    OutPutTree(k);
}

sw.Flush();
sw.Close();

void OutPutTree(int _k)
{
    int rootNodeIndex = (int)Math.Pow(2, _k - 1) - 1;
    int interval = (int)Math.Pow(2, _k - 2);

    Queue<Info> q = new Queue<Info>();
    Info temp = null;
    q.Enqueue(new Info(interval, rootNodeIndex, 0));
    resultList.Add(new List<int>() { InorderTraResult[rootNodeIndex] });

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        rootNodeIndex = temp.index;
        interval = temp.interval;

        if (interval == 0)
        {
            continue;
        }

        if (temp.depth + 1 == resultList.Count)
        {
            resultList.Add(new List<int>());
        }

        resultList[temp.depth + 1].Add(InorderTraResult[rootNodeIndex - interval]);
        resultList[temp.depth + 1].Add(InorderTraResult[rootNodeIndex + interval]);

        q.Enqueue(new Info(interval / 2, rootNodeIndex - interval, temp.depth + 1));
        q.Enqueue(new Info(interval / 2, rootNodeIndex + interval, temp.depth + 1));
    }

    for (int i = 0; i < resultList.Count; i++)
    {
        sw.WriteLine(string.Join(" ", resultList[i]));
    }
}

class Info
{
    public int interval;
    public int index;
    public int depth;

    public Info(int interval, int index, int depth)
    {
        this.interval = interval;
        this.index = index;
        this.depth = depth;
    }
}