StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[] bytes = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 사용중인 메모리 바이트 수
int[] costs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // 비활성화 했을 경우 비용

int sum = costs.Sum();
int[,] arr = new int[n, sum + 1];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < sum + 1; j++)
    {
        if (j - costs[i] >= 0)
        {
            arr[i, j] = Math.Max(arr[i, j], (i == 0 ? 0 : arr[i - 1, j - costs[i]]) + bytes[i]);
        }

        arr[i, j] = Math.Max(arr[i, j], (i == 0 ? 0 : arr[i - 1, j]));
    }
}

int result = 0;

for (int i = 0; i < sum + 1; i++)
{
    if (arr[n - 1, i] >= m)
    {
        result = i;
        break;
    }
}

sw.Write(result);
sw.Flush();
sw.Close();