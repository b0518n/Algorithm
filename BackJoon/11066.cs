StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
int k = 0;
int[] sizes = null;

for (int i = 0; i < t; i++)
{
    k = int.Parse(Console.ReadLine());
    sizes = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    int result = Solve(sizes);
    sw.WriteLine(result);
}

sw.Flush();
sw.Close();

int Solve(int[] sizes)
{
    int[,] arr = new int[sizes.Length + 2, sizes.Length + 2];
    int[] sum = new int[sizes.Length + 1];
    for (int i = 1; i <= sizes.Length; i++)
    {
        sum[i] = sum[i - 1] + sizes[i - 1];
    }

    for (int i = 1; i <= sizes.Length; i++) // 길이
    {
        for (int j = 1; j <= sizes.Length - i + 1; j++)
        {
            if (i == 1)
            {
                arr[j, j] = sizes[j - 1];
            }
            else if (i == 2)
            {
                arr[j, j + 1] = sizes[j - 1] + sizes[j];
            }
            else
            {
                arr[j, j + i - 1] = int.MaxValue;
                for (int k = j; k <= j + i - 1; k++)
                {
                    // j == k or k + 1 == j + i - 1 일경우 sum[j + i - 1] - sum[j - 1]에 해당 값이 더해져 있으므로 또 더할경우 2번 더하기 떄문에 오답 발생. 
                    arr[j, j + i - 1] = Math.Min(arr[j, j + i - 1], (j != k ? arr[j, k] : 0) + (k + 1 != j + i - 1 ? arr[k + 1, j + i - 1] : 0) + sum[j + i - 1] - sum[j - 1]);
                }

            }
        }
    }

    return arr[1, k];
}