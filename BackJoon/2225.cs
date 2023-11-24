int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int[,] dp = new int[201, 201];

for (int i = 0; i < 201; i++)
{
    dp[1, i] = 1;
    dp[i, 0] = 1;
}

dp[0, 0] = 0;

for (int i = 1; i < 201; i++)
{
    for (int j = 1; j < 201; j++)
    {
        dp[i, j] = (dp[i, j - 1] + dp[i - 1, j]) % 1000000000;
    }
}

Console.WriteLine(dp[k, n]);