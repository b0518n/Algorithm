StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 동전의 개수
int k = input[1]; // k원

int[] coins = new int[n];

for (int i = 0; i < n; i++)
{
    coins[i] = int.Parse(Console.ReadLine());
}

Array.Sort(coins);
long[,] arr = new long[2, k + 1];
arr[1, 0] = 1;

for (int i = 1; i <= n; i++)
{
    for (int j = 1; j <= k; j++)
    {
        if (coins[i - 1] > j)
        {
            arr[1, j] = arr[0, j];
        }
        else
        {
            arr[1, j] = arr[0, j] + arr[1, j - coins[i - 1]];
        }
    }

    for (int j = 1; j <= k; j++)
    {
        arr[0, j] = arr[1, j];
    }
}

sw.WriteLine(arr[0, k]);
sw.Flush();
sw.Close();