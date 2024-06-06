StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int n = input[0]; // 1 <= n <= 12
int d = input[1]; // 1 <= d <= 10,000

Dictionary<int, List<RouteInfo>> dic = new Dictionary<int, List<RouteInfo>>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    if (input[1] > d)
        continue;

    if (input[1] - input[0] <= input[2])
        continue;

    if (!dic.ContainsKey(input[0]))
    {
        dic.Add(input[0], new List<RouteInfo>());
        dic[input[0]].Add(new RouteInfo(input[1], input[2]));
    }
    else
    {
        dic[input[0]].Add(new RouteInfo(input[1], input[2]));
    }
}

int[] dp = new int[d + 1];
RouteInfo temp = null;
for (int i = 0; i < d + 1; i++)
{
    if (i == 0)
    {
        if (dic.ContainsKey(i))
        {
            for (int j = 0; j < dic[i].Count; j++)
            {
                temp = dic[i][j];
                if (dp[temp.destinationPos] == 0)
                {
                    dp[temp.destinationPos] = dp[i] + temp.distance;
                }
                else if (dp[temp.destinationPos] > dp[i] + temp.distance)
                {
                    dp[temp.destinationPos] = dp[i] + temp.distance;
                }
            }
        }
    }
    else
    {
        if (dp[i] == 0)
            dp[i] = dp[i - 1] + 1;
        else if (dp[i] > dp[i - 1] + 1)
            dp[i] = dp[i - 1] + 1;

        if (dic.ContainsKey(i))
        {
            for (int j = 0; j < dic[i].Count; j++)
            {
                temp = dic[i][j];
                if (dp[temp.destinationPos] == 0)
                {
                    dp[temp.destinationPos] = dp[i] + temp.distance;
                }
                else if (dp[temp.destinationPos] > dp[i] + temp.distance)
                {
                    dp[temp.destinationPos] = dp[i] + temp.distance;
                }
            }
        }
    }
}

sw.WriteLine(dp[d]);
sw.Flush();
sw.Close();

class RouteInfo
{
    public int destinationPos;
    public int distance;

    public RouteInfo(int destinationPos, int distance)
    {
        this.destinationPos = destinationPos;
        this.distance = distance;
    }
}