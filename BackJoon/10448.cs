StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] dp = new int[45];
for (int i = 1; i < 45; i++)
{
    dp[i] = i * (i + 1) / 2;
}

bool isPossible = false;

int t = int.Parse(sr.ReadLine());
int k = 0;

for (int i = 0; i < t; i++)
{
    isPossible = false;
    k = int.Parse(sr.ReadLine());

    for (int j = 44; j >= 1; j--)
    {
        if (isPossible)
            break;

        if (dp[j] >= k)
            continue;

        k -= dp[j];
        for (int l = j; l >= 1; l--)
        {
            if (isPossible)
                break;
            if (dp[l] >= k)
                continue;

            k -= dp[l];
            for (int n = l; n >= 1; n--)
            {
                if (dp[n] == k)
                {
                    isPossible = true;
                    break;
                }

            }
            if (!isPossible)
            {
                k += dp[l];
            }
        }
        if (!isPossible)
        {
            k += dp[j];
        }
    }

    if (isPossible)
    {
        sw.WriteLine(1);
    }
    else
    {
        sw.WriteLine(0);
    }
}

sw.Flush();
sw.Close();