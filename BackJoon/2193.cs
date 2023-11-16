int n = int.Parse(Console.ReadLine());
long[] dp = new long[91];
dp[1] = 1;
dp[2] = 1;

for (int i = 3; i <= n; i++)
{
    dp[i] = dp[i - 1] + dp[i - 2];
}

Console.WriteLine(dp[n]);