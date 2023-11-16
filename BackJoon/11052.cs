int n = int.Parse(Console.ReadLine());
int[] dp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

List<int> temp = dp.ToList();
temp.Insert(0, 0);
dp = temp.ToArray();

for (int i = 2; i < n + 1; i++)
{
    for (int j = 1; j < i + 1; j++)
    {
        dp[i] = Math.Max(dp[j] + dp[i - j], dp[i]);
    }
}

Console.WriteLine(dp[n]);