StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] input = null;
int[,] forest = new int[n, n];
int[,] dp = new int[n, n];
int result = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        forest[i, j] = input[j];
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (dp[i, j] == 0)
        {
            result = Math.Max(result, DFS(i, j));
        }
    }
}

sw.WriteLine(result);
sw.Close();

int DFS(int y, int x)
{
    if (dp[y, x] != 0)
    {
        return dp[y, x];
    }

    int ny = 0;
    int nx = 0;
    int value = 0;
    int maxMove = 1;

    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || nx < 0 || ny >= n || nx >= n)
        {
            continue;
        }

        if (forest[ny, nx] <= forest[y, x])
        {
            continue;
        }

        value = DFS(ny, nx) + 1;
        maxMove = Math.Max(maxMove, value);
    }

    return dp[y, x] = maxMove;
}