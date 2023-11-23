int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int[] arr = new int[n];

int temp = 0;

for (int i = 0; i < n; i++)
{
    temp = int.Parse(Console.ReadLine());
    arr[i] = temp;
}

Array.Sort(arr);

int[] dp = new int[10001];
dp[0] = -1;
int index = 0;

for (int i = 1; i < 10001; i++)
{
    if (index < arr.Length - 1 && i >= arr[index + 1])
    {
        index++;
    }

    for (int j = index; j >= 0; j--)
    {
        if (j == 0 && i < arr[j])
        {
            dp[i] = -1;
            break;
        }

        if (i == arr[j])
        {
            dp[i] = 1;
        }

        if (dp[i - arr[j]] == -1)
        {
            if (j == 0)
            {
                if (dp[i] == 0)
                {
                    dp[i] = -1;
                }
            }
            else
            {
                continue;
            }
        }
        else
        {
            if (dp[i] == 0)
            {
                dp[i] = dp[i - arr[j]] + 1;
            }
            else
            {
                dp[i] = Math.Min(dp[i], dp[i - arr[j]] + 1);
            }
        }
    }
}

Console.WriteLine(dp[k]);