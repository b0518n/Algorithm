int n = int.Parse(Console.ReadLine());
int[] dp = new int[1001];
int[] arr = new int[11];
dp[1] = 10;

for (int i = 1; i < 11; i++)
{
    arr[i] = i;
}

for (int i = 2; i < 1001; i++)
{
    for (int j = 2; j < 11; j++)
    {
        arr[j] = (arr[j - 1] + arr[j]) % 10007;
    }

    dp[i] = arr[10];
}

Console.WriteLine(dp[n]);