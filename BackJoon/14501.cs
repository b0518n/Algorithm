int n = int.Parse(Console.ReadLine());
int[] input = null;
List<int[]> dp = new List<int[]>();
int max = -1;
int sum = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    dp.Add(new int[2] { input[0], input[1] });
}

Recursion(n, -1, sum, -1);
Console.WriteLine(max);

void Recursion(int n, int index, int sum, int a)
{
    for (int i = index + 1; i < n; i++)
    {
        if (i + dp[i][0] - 1 < n && i >= a)
        {
            sum += dp[i][1];
            Recursion(n, i, sum, i + dp[i][0]);
            sum -= dp[i][1];
        }
    }

    max = Math.Max(max, sum);
}