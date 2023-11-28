int n = int.Parse(Console.ReadLine());
int[] dp = new int[100001];
dp[1] = 3;
dp[2] = 7;

for (int i = 3; i < 100001; i++)
{
    dp[i] = (dp[i - 1] * 2) % 9901 + dp[i - 2] % 9901;
    dp[i] %= 9901;
}

Console.WriteLine(dp[n]);