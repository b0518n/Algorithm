StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int r = input[2];

int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int[,] searchRangeArr = new int[n + 1, n + 1];
for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (i == j)
            continue;

        searchRangeArr[i, j] = int.MaxValue;
    }
}

for (int i = 0; i < r; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    searchRangeArr[input[0], input[1]] = input[2];
    searchRangeArr[input[1], input[0]] = input[2];
}

int result = 0;
FloydWarshall_Fun();
MaxItemCnt();

sw.WriteLine(result);
sw.Flush();
sw.Close();

void FloydWarshall_Fun()
{
    for (int i = 1; i < n + 1; i++) // 중간
    {
        for (int j = 1; j < n + 1; j++) // 시작
        {
            if (i == j)
                continue;
            if (searchRangeArr[j, i] == int.MaxValue)
                continue;
            for (int k = 1; k < n + 1; k++) // 목적지
            {
                if (j == k)
                    continue;
                if (searchRangeArr[i, k] == int.MaxValue)
                    continue;

                searchRangeArr[j, k] = Math.Min(searchRangeArr[j, k], searchRangeArr[j, i] + searchRangeArr[i, k]);
            }
        }
    }
}
void MaxItemCnt()
{
    int cnt = 0;

    for (int i = 1; i < n + 1; i++)
    {
        cnt = 0;
        cnt += arr[i - 1];
        for (int j = 1; j < n + 1; j++)
        {
            if (i == j)
                continue;
            if (searchRangeArr[i, j] == int.MaxValue || searchRangeArr[i, j] > m)
                continue;

            cnt += arr[j - 1];
        }

        if (result == 0)
            result = cnt;
        else
            result = Math.Max(result, cnt);
    }
}