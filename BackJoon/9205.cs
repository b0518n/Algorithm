int t = int.Parse(Console.ReadLine());
int n = -1;
int[] input = null;
List<int[]> stores = null;
int hy = 0, hx = 0; // 집 위치
int dy = 0, dx = 0; // 목적지 위치
StringBuilder sb = new StringBuilder();

for (int i = 0; i < t; i++)
{
    n = int.Parse(Console.ReadLine());
    stores = new List<int[]>();
    for (int j = 0; j < n + 2; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        if (j == 0)
        {
            hx = input[0];
            hy = input[1];
        }
        else if (j == n + 1)
        {
            dx = input[0];
            dy = input[1];
        }
        else
        {
            stores.Add(new int[2] { input[1], input[0] });
        }
    }

    BFS(hy, hx, 20);
}

Console.WriteLine(sb.ToString());


void BFS(int y, int x, int bottleCnt)
{
    Queue<DataInfo> q = new Queue<DataInfo>();
    q.Enqueue(new DataInfo(y, x, bottleCnt));

    int _y = 0, _x = 0, _cnt = 0;
    int[] _visited = new int[stores.Count];
    DataInfo dataInfo = null;

    while (q.Count > 0)
    {
        dataInfo = q.Dequeue();

        if (stores.Count == 0)
        {
            if (CalDistDestination(dataInfo.y, dataInfo.x) <= dataInfo.cnt * 50)
            {
                sb.AppendLine("happy");
                return;
            }
            else
            {
                sb.AppendLine("sad");
                return;
            }
        }

        if (CalDistDestination(dataInfo.y, dataInfo.x) <= dataInfo.cnt * 50)
        {
            sb.AppendLine("happy");
            return;
        }

        for (int i = 0; i < stores.Count; i++)
        {
            _y = dataInfo.y;
            _x = dataInfo.x;
            _cnt = dataInfo.cnt;

            if (_visited[i] == 1)
            {
                continue;
            }

            if (CalDistStore(_y, _x, i) <= _cnt * 50)
            {
                _visited[i] = 1;
                q.Enqueue(new DataInfo(stores[i][0], stores[i][1], 20));
            }
            else
            {
                continue;
            }
        }
    }

    sb.AppendLine("sad");
}

int CalDistStore(int y, int x, int index)
{
    int sy = stores[index][0]; // 가장 가까운 편의점의 y값
    int sx = stores[index][1]; // 가장 가까운 편의점의 x값

    return Math.Abs(sy - y) + Math.Abs(sx - x);
}

int CalDistDestination(int y, int x)
{
    return Math.Abs(dy - y) + Math.Abs(dx - x);
}

class DataInfo
{
    public int y;
    public int x;
    public int cnt;

    public DataInfo(int y, int x, int cnt)
    {
        this.y = y;
        this.x = x;
        this.cnt = cnt;
    }
}