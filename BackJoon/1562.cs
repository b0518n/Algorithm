StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
Dictionary<int, long>[,] dp = new Dictionary<int, long>[10, n];
long result = 0;

dp[0, 0] = new Dictionary<int, long>();

if (n >= 10)
{
    for (int i = 1; i < 10; i++)
    {
        dp[i, 0] = new Dictionary<int, long>() { };
        dp[i, 0].Add(1 << i, 1);

    }

    int[] dy = new int[2] { -1, 1 };
    int[] dx = new int[2] { 1, 1 };

    int ny = 0;
    int nx = 0;

    for (int j = 0; j < n; j++)
    {
        for (int i = 0; i < 10; i++)
        {
            if (dp[i, j].Count == 0)
            {
                continue;
            }

            for (int k = 0; k < 2; k++)
            {
                ny = i + dy[k];
                nx = j + dx[k];

                if (ny < 0 || nx < 0 || ny >= 10 || nx >= n)
                {
                    continue;
                }

                if (dp[ny, nx] == null)
                {
                    dp[ny, nx] = new Dictionary<int, long>();
                    foreach (int key in dp[i, j].Keys)
                    {
                        if (!dp[ny, nx].ContainsKey(key | 1 << ny))
                        {
                            dp[ny, nx].Add(key | 1 << ny, dp[i, j][key]);
                        }
                        else
                        {
                            dp[ny, nx][key | 1 << ny] += dp[i, j][key] % 1000000000;
                        }
                    }
                }
                else
                {
                    foreach (int key in dp[i, j].Keys)
                    {
                        if (!dp[ny, nx].ContainsKey(key | 1 << ny))
                        {
                            dp[ny, nx].Add(key | 1 << ny, dp[i, j][key]);
                        }
                        else
                        {
                            dp[ny, nx][key | 1 << ny] += dp[i, j][key] % 1000000000;
                        }
                    }
                }
            }
        }
    }

    for (int i = 0; i < 10; i++)
    {
        if (dp[i, n - 1].Count == 0)
        {
            continue;
        }

        foreach (int key in dp[i, n - 1].Keys)
        {
            if (key == (1 << 10) - 1)
            {
                result += dp[i, n - 1][key] % 1000000000;
            }
        }
    }
}

sw.WriteLine(result % 1000000000);
sw.Close();