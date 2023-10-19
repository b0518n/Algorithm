int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int r = input[0];
int c = input[1];

string str = null;
string[,] dp = new string[r, c];
for (int i = 0; i < r; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < c; j++)
    {
        dp[i, j] = str[j].ToString();
    }
}

Dictionary<string, int> dics = new Dictionary<string, int>();

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

int max = -1;

dics.Add(dp[0, 0], 1);
DFS(0, 0, 1);

Console.WriteLine(max);

void DFS(int y, int x, int result)
{
    max = Math.Max(max, result);

    int ny = 0;
    int nx = 0;

    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || nx < 0 || ny >= r || nx >= c)
        {
            continue;
        }

        if (dics.ContainsKey(dp[ny, nx]))
        {
            continue;
        }

        dics.Add(dp[ny, nx], 1);
        DFS(ny, nx, result + 1);
        dics.Remove(dp[ny, nx]);
    }
}