int n = int.Parse(Console.ReadLine());
int[] dp = new int[31];

dp[2] = 3;
dp[4] = 11;
dp[6] = 41;

for (int i = 8; i <= 30; i += 2)
{
    dp[i] = 3 * dp[i - 2] + 2;
    for (int j = i - 4; j >= 0; j -= 2)
    {
        dp[i] += 2 * dp[j];
    }
}

Console.WriteLine(dp[n]);