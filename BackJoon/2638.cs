int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0], m = input[1];
int[,] dp = new int[n, m];
int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
Dictionary<string, int> cheezes = new Dictionary<string, int>();
List<string> exposedCheezes = new List<string>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        if (input[j] == 1)
        {
            dp[i, j] = 0;
            cheezes.Add($"{i} {j}", 1);
        }
        else if (input[j] == 0)
        {
            dp[i, j] = -1;
        }
    }
}

SearchOutSideAir(0, 0);
string[] temp = null;
int time = 0;

while (cheezes.Count > 0)
{
    foreach (string str in cheezes.Keys)
    {
        temp = str.Split(" ");
        DistinguishCheeze(int.Parse(temp[0]), int.Parse(temp[1]));
        if (dp[int.Parse(temp[0]), int.Parse(temp[1])] == 2)
        {
            exposedCheezes.Add($"{temp[0]} {temp[1]}");
        }
    }

    foreach (string str in exposedCheezes)
    {
        temp = str.Split(" ");
        dp[int.Parse(temp[0]), int.Parse(temp[1])] = -2;
        cheezes.Remove(str);
    }

    exposedCheezes.Clear();
    SearchOutSideAir(0, 0);
    time++;
}

Console.WriteLine(time);

void DistinguishCheeze(int y, int x)
{
    int cnt = 0;
    int ny = 0;
    int nx = 0;

    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || nx < 0 || ny >= n || nx >= m)
        {
            continue;
        }

        if (dp[ny, nx] == -2)
        {

            cnt++;
        }
    }

    if (cnt >= 2)
    {
        dp[y, x] = 2;
    }
    else if (cnt == 1)
    {
        dp[y, x] = 1;
    }
    else
    {
        dp[y, x] = 0;
    }
}

void SearchOutSideAir(int y, int x)
{
    Queue<ObjectInfo> q = new Queue<ObjectInfo>();
    q.Enqueue(new ObjectInfo(y, x));
    int[,] visited = new int[n, m];
    int ny = 0;
    int nx = 0;
    ObjectInfo temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= m)
            {
                continue;
            }

            if (visited[ny, nx] == 1)
            {
                continue;
            }

            if (dp[ny, nx] >= 0)
            {
                continue;
            }

            q.Enqueue(new ObjectInfo(ny, nx));
            dp[ny, nx] = -2;
            visited[ny, nx] = 1;
        }
    }
}

class ObjectInfo
{
    public int y;
    public int x;

    public ObjectInfo(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}