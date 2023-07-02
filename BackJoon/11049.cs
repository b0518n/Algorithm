StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] input = null;
int[,] arr = new int[n + 1, n + 1];
int r = 0;
int c = 0;
int[,] matrixs = new int[2, n + 1];

for (int i = 1; i < n + 1; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    r = input[0];
    c = input[1];

    matrixs[0, i] = r;
    matrixs[1, i] = c;
}

for (int i = 2; i <= n; i++)
{
    for (int j = 1; j <= n - i + 1; j++)
    {
        if (i == 2)
        {
            arr[j, j + i - 1] = matrixs[0, j] * matrixs[1, j] * matrixs[1, j + i - 1];
        }
        else
        {
            arr[j, j + i - 1] = int.MaxValue;
            for (int k = j; k < j + i - 1; k++)
            {
                arr[j, j + i - 1] = Math.Min(arr[j, j + i - 1], arr[j, k] + arr[k + 1, j + i - 1] + (matrixs[0, j] * matrixs[0, k + 1] * matrixs[1, j + i - 1]));
            }
        }
    }
}

int result = arr[1, n];
sw.Write(result);
sw.Flush();
sw.Close();