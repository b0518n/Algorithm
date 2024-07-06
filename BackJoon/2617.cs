StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

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
    arr[input[0], input[1]] = -1;
    arr[input[1], input[0]] = 1;
}

for (int i = 1; i < n + 1; i++) // 중간
{
    for (int j = 1; j < n + 1; j++) //시작
    {
        if (i == j)
            continue;
        if (arr[j, i] == int.MaxValue)
            continue;

        for (int k = 1; k < n + 1; k++)
        {
            if (i == k)
                continue;

            if (arr[j, i] == arr[i, k])
            {
                arr[j, k] = arr[j, i];
            }
        }
    }
}

int result = 0;
int middle = (n + 1) / 2;

for (int i = 1; i < n + 1; i++)
{
    int lighterMarbleCnt = 0;
    int heavierMarbleCnt = 0;

    for (int j = 1; j < n + 1; j++)
    {
        if (arr[i, j] == -1)
            lighterMarbleCnt++;
        if (arr[i, j] == 1)
            heavierMarbleCnt++;
    }

    if (lighterMarbleCnt >= middle || heavierMarbleCnt >= middle)
    {
        result++;
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();