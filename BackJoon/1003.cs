StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
Info[] dp = new Info[41];
dp[0] = new Info(1, 0);
dp[1] = new Info(0, 1);

for (int i = 2; i < 41; i++)
{
    dp[i] = new Info(dp[i - 1].zeroCnt + dp[i - 2].zeroCnt, dp[i - 1].oneCnt + dp[i - 2].oneCnt);
}

int t = int.Parse(sr.ReadLine());
int n = 0;

for (int i = 0; i < t; i++)
{
    n = int.Parse(sr.ReadLine());
    sw.WriteLine($"{dp[n].zeroCnt} {dp[n].oneCnt}");
}

sw.Flush();
sw.Close();

class Info
{
    public int zeroCnt;
    public int oneCnt;

    public Info(int zeroCnt, int oneCnt)
    {
        this.zeroCnt = zeroCnt;
        this.oneCnt = oneCnt;
    }
}