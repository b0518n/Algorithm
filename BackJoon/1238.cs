StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int x = input[2];

int[,] arr = new int[n + 1, n + 1];
for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (i == j)
            continue;
        arr[i, j] = int.MaxValue;
    }
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    arr[input[0], input[1]] = input[2];
}

FloydWarshall_Fun(n);
int result = 0;
for (int i = 1; i < n + 1; i++)
{
    result = Math.Max(result, arr[i, x] + arr[x, i]);
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

void FloydWarshall_Fun(int _cnt)
{
    for (int i = 1; i < _cnt + 1; i++) // 중간 지점
    {
        for (int j = 1; j < _cnt + 1; j++) // 시작 지점
        {
            if (arr[j, i] == int.MaxValue)
                continue;

            for (int k = 1; k < _cnt + 1; k++) // 도착 지점
            {
                if (i == k)
                    continue;
                if (arr[i, k] == int.MaxValue)
                    continue;

                if (arr[j, k] == int.MaxValue)
                {
                    arr[j, k] = arr[j, i] + arr[i, k];
                }
                else
                {
                    if (arr[j, k] > arr[j, i] + arr[i, k])
                    {
                        arr[j, k] = arr[j, i] + arr[i, k];
                    }
                }
            }
        }
    }
}