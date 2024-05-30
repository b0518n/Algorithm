StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = null;

List<int>[] edgeList = new List<int>[n + 1];

for (int i = 1; i < n + 1; i++)
{
    edgeList[i] = new List<int>();
}

for (int i = 0; i < n - 1; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    edgeList[input[0]].Add(input[1]);
    edgeList[input[1]].Add(input[0]);
}

int rootNodeNumber = 1;
int cnt = 0;

GetDistance();

if (cnt % 2 == 0)
    sw.WriteLine("No");
else
    sw.WriteLine("Yes");

sw.Flush();
sw.Close();

void GetDistance()
{
    Stack<Info> stack = new Stack<Info>();
    stack.Push(new Info(rootNodeNumber, 0));

    int[] visited = new int[n + 1];
    visited[rootNodeNumber] = 1;

    Info temp = null;

    while (stack.Count > 0)
    {
        temp = stack.Pop();

        if (edgeList[temp.number].Count == 1 && temp.number != rootNodeNumber)
        {
            cnt += temp.distance;
            continue;
        }

        foreach (int child in edgeList[temp.number])
        {
            if (visited[child] == 1)
                continue;

            stack.Push(new Info(child, temp.distance + 1));
            visited[child] = 1;
        }
    }
}

class Info
{
    public int number;
    public int distance;

    public Info(int number, int distance)
    {
        this.number = number;
        this.distance = distance;
    }
}