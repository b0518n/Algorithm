StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] arr = new int[n + 1];
Dictionary<int, List<Info>> dic = new Dictionary<int, List<Info>>();
SortedSet<Info> pq = new SortedSet<Info>(new MyComparer());

for (int i = 1; i < n + 1; i++)
{
    arr[i] = int.MaxValue;
    dic.Add(i, new List<Info>());
}

arr[1] = 0;

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    dic[input[0]].Add(new Info(input[1], input[2]));
    dic[input[1]].Add(new Info(input[0], input[2]));
}

pq.Add(new Info(1, 0));
Info temp = null;
int destination = 0;
int cost = 0;

while (pq.Count > 0)
{
    temp = pq.First();
    destination = temp.destination;
    cost = temp.cost;

    foreach (Info info in dic[destination])
    {
        if (arr[info.destination] == int.MaxValue)
        {
            arr[info.destination] = cost + info.cost;
            pq.Add(new Info(info.destination, cost + info.cost));
        }
        else
        {
            if (arr[info.destination] > cost + info.cost)
            {
                arr[info.destination] = cost + info.cost;
                pq.Add(new Info(info.destination, cost + info.cost));
            }
        }
    }

    pq.Remove(temp);
}

sw.WriteLine(arr[n]);
sw.Flush();
sw.Close();

class Info
{
    public int destination;
    public int cost;

    public Info(int _destination, int _cost)
    {
        this.destination = _destination;
        this.cost = _cost;
    }
}
class MyComparer : IComparer<Info>
{
    public int Compare(Info x, Info y)
    {
        if (x.cost == y.cost)
            return x.destination - y.destination;
        return x.cost - y.cost;
    }
}