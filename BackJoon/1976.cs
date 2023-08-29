StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

int[] input = null;
int[,] dp = new int[n + 1, n + 1];

for (int i = 1; i < n + 1; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 1; j < n + 1; j++)
    {
        dp[i, j] = input[j - 1];
    }
}

int[] plan = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Floyd_warshall(dp, n);

bool isMove = true;
int start = plan[0];

for (int i = 1; i < m; i++)
{
    if (dp[start, plan[i]] == 0 && start != plan[i])
    {
        isMove = false;
        break;
    }
}

if (!isMove)
{
    sb.AppendLine("NO");
}
else
{
    sb.AppendLine("YES");
}

Console.WriteLine(sb.ToString());

void Floyd_warshall(int[,] dp, int n)
{
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (dp[j, i] == 0)
            {
                continue;
            }

            for (int k = 1; k < n + 1; k++)
            {
                if (dp[i, k] == 0)
                {
                    continue;
                }

                dp[j, k] = 1;
            }
        }
    }
}