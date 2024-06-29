StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] input = null;
int[,] arr = new int[n, n];

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        arr[i, j] = input[j];
    }
}

Floyd_Warshall_Func();
Print_Func();

void Floyd_Warshall_Func()
{
    for (int i = 0; i < n; i++) // 중간
    {
        for (int j = 0; j < n; j++) // 시작
        {
            if (i == j)
                continue;
            if (arr[j, i] == 0)
                continue;

            for (int k = 0; k < n; k++)
            {
                if (arr[i, k] == 0)
                    continue;
                arr[j, k] = 1;
            }
        }
    }
}
void Print_Func()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (j == n - 1)
            {
                sw.WriteLine(arr[i, j]);
            }
            else
            {
                sw.Write(arr[i, j] + " ");
            }
        }
    }

    sw.Flush();
    sw.Close();
}