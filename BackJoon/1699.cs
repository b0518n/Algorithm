int n = int.Parse(Console.ReadLine());
int[] dp = new int[100001];
for (int i = 1; i <= 316; i++)
{
    dp[i * i] = 1;
}

int count = 1;

for (int i = 2; i < 100001; i++)
{
    if (dp[i] != 0)
    {
        count++;
        continue;
    }

    for (int j = count; j >= 0; j--)
    {
        if (dp[i] == 0)
        {
            dp[i] = dp[j * j] + dp[i - (j * j)];
        }
        else
        {
            dp[i] = Math.Min(dp[i], dp[j * j] + dp[i - (j * j)]);
        }
    }
}

Console.WriteLine(dp[n]);