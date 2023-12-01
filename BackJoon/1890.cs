int n = int.Parse(Console.ReadLine());
int[,] arr = new int[n, n];
long[,] dp = new long[n, n];

int[] input = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        arr[i, j] = input[j];
    }
}

dp[0, 0] = 1;
Solve();
Console.WriteLine(dp[n - 1, n - 1]);

void Solve()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == n - 1 && j == n - 1)
            {
                return;
            }

            if (j + arr[i, j] >= 0 && j + arr[i, j] <= n - 1)
            {
                dp[i, j + arr[i, j]] += dp[i, j];
            }

            if (i + arr[i, j] >= 0 && i + arr[i, j] <= n - 1)
            {
                dp[i + arr[i, j], j] += dp[i, j];
            }
        }
    }
}