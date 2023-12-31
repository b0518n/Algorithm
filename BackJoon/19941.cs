int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
string str = Console.ReadLine();
int[] dp = new int[n];
int result = 0;

for (int i = 0; i < n; i++)
{
    if (str[i] == 'H')
    {
        for (int j = -k; j < k + 1; j++)
        {
            if (i + j > n - 1 || i + j < 0)
            {
                continue;
            }

            if (str[i + j] == 'H')
            {
                continue;
            }
            else
            {
                if (dp[i + j] == 0)
                {
                    result++;
                    dp[i + j] = 1;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
    else
    {
        continue;
    }
}

Console.WriteLine(result);