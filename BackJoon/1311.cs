StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] input = null;
int[,] cost = new int[n, n];
int[,] dp = new int[n, (1 << n)];


for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
    for (int j = 0; j < n; j++)
    {
        cost[i, j] = input[j];
    }
}

sw.WriteLine(DP(0, 0));
sw.Flush();
sw.Close();

int DP(int humanIndex, int completedWork)
{
    if (humanIndex == n) return 0;

    if (dp[humanIndex, completedWork] != 0) return dp[humanIndex, completedWork];

    int result = int.MaxValue;
    for (int i = 0; i < n; i++)
    {
        if ((completedWork & (1 << i)) == 0)
        {
            result = Math.Min(result, cost[humanIndex, i] + DP(humanIndex + 1, completedWork | (1 << i)));
        }
    }

    dp[humanIndex, completedWork] = result;
    return dp[humanIndex, completedWork];
}