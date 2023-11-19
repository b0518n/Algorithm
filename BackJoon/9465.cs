int t = int.Parse(Console.ReadLine());
int n = 0;

int result = 0;
int[,] dp = null;
int[] input = null;

for (int i = 0; i < t; i++)
{
    result = 0;
    n = int.Parse(Console.ReadLine());
    dp = new int[2, n];

    for (int j = 0; j < 2; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int k = 0; k < n; k++)
        {
            dp[j, k] = input[k];
        }
    }

    if (n > 1)
    {
        dp[0, 1] += dp[1, 0];
        dp[1, 1] += dp[0, 0];

        for (int j = 2; j < n; j++)
        {
            dp[0, j] += Math.Max(dp[1, j - 1], dp[1, j - 2]);
            dp[1, j] += Math.Max(dp[0, j - 1], dp[0, j - 2]);
        }
    }

    result = Math.Max(dp[0, n - 1], dp[1, n - 1]);
    Console.WriteLine(result);
}