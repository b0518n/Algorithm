int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[,] dp = new int[n, m];

int[] temp = null;
int max = 0;

for (int i = 0; i < n; i++)
{
    temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        dp[i, j] = temp[j];

        max = 0;

        if (i - 1 >= 0 && j - 1 >= 0)
        {
            max = Math.Max(dp[i - 1, j], dp[i, j - 1]);
        }
        else if (i - 1 >= 0 && j - 1 < 0)
        {
            max = dp[i - 1, j];
        }
        else if (i - 1 < 0 && j - 1 >= 0)
        {
            max = dp[i, j - 1];
        }

        dp[i, j] += max;
    }
}

Console.WriteLine(dp[n - 1, m - 1]);