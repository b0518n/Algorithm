using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int n = 0;
int[] dp = new int[11];
dp[1] = 1;
dp[2] = 2;
dp[3] = 4;

for (int i = 4; i < 11; i++)
{
    dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
}

for (int i = 0; i < t; i++)
{
    n = int.Parse(Console.ReadLine());
    sb.AppendLine(dp[n].ToString());
}

Console.WriteLine(sb.ToString());