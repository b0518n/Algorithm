StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] dp = new int[n, m];
int[,] visited = new int[n, m];
int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
PositionInfo start = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        if (input[j] == 2)
        {
            dp[i, j] = 0;
            start = new PositionInfo(i, j);
        }
        else
        {
            dp[i, j] = input[j];
        }
    }
}

BFS(start.y, start.x);
CheckInAccessablePos();
PrintArr();

void BFS(int y, int x)
{
    Queue<PositionInfo> q = new Queue<PositionInfo>();
    q.Enqueue(new PositionInfo(y, x));
    int ny = 0;
    int nx = 0;
    PositionInfo temp = null;
    visited[y, x] = 1;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= m || visited[ny, nx] == 1 || dp[ny, nx] == 0)
            {
                continue;
            }

            dp[ny, nx] = dp[temp.y, temp.x] + 1;
            q.Enqueue(new PositionInfo(ny, nx));
            visited[ny, nx] = 1;
        }
    }
}

void CheckInAccessablePos()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (visited[i, j] == 0 && dp[i, j] == 1)
            {
                dp[i, j] = -1;
            }
        }
    }
}

void PrintArr()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (j == m - 1)
            {
                sw.WriteLine(dp[i, j]);
            }
            else
            {
                sw.Write(dp[i, j] + " ");
            }
        }
    }

    sw.Flush();
    sw.Close();
}

class PositionInfo
{
    public int y;
    public int x;

    public PositionInfo(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}