using System.Text;

int n = int.Parse(Console.ReadLine());
int[,] dp = new int[n, n];
int[] input = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        dp[i, j] = input[j];
    }
}

int[] dy = new int[3] { 0, 1, 1 };
int[] dx = new int[3] { 1, 0, 1 };

DFS(0, 1, 0);

if (dp[n - 1, n - 1] == 1)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(-1 * dp[n - 1, n - 1]);
}

// 0 : 가로, 1 : 세로, 2 : 대각선
void DFS(int y, int x, int direction)
{
    int ny = 0;
    int nx = 0;

    for (int i = 0; i < 3; i++)
    {
        if (direction == 0 && i == 1)
        {
            continue;
        }

        if (direction == 1 && i == 0)
        {
            continue;
        }

        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || nx < 0 || ny >= n || nx >= n)
        {
            continue;
        }

        if (i != 2)
        {
            if (dp[ny, nx] == 1)
            {
                continue;
            }
            else
            {
                dp[ny, nx]--;
                DFS(ny, nx, i);
            }
        }
        else
        {
            if (dp[ny - 1, nx] == 1 || dp[ny, nx - 1] == 1 || dp[ny, nx] == 1)
            {
                continue;
            }
            else
            {
                dp[ny, nx]--;
                DFS(ny, nx, 2);
            }
        }
    }
}