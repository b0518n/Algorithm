StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] arr = new int[n + 1, n + 1];
InitArr_Func();
Input_Func();
Floyd_Warshall_Func();
sw.WriteLine(GetStudentCnt_Fun());
sw.Flush();
sw.Close();

void InitArr_Func()
{
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (i == j)
                continue;
            arr[i, j] = int.MaxValue;
        }
    }
}
void Input_Func()
{
    for (int i = 0; i < m; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        arr[input[0], input[1]] = 1;
        arr[input[1], input[0]] = -1;
    }
}
void Floyd_Warshall_Func()
{
    for (int i = 1; i < n + 1; i++) // 중간
    {
        for (int j = 1; j < n + 1; j++) // 시작
        {
            if (i == j)
                continue;
            if (arr[j, i] == int.MaxValue)
                continue;
            for (int k = 1; k < n + 1; k++) // 끝
            {
                if (i == k)
                    continue;
                if (arr[i, k] == int.MaxValue || arr[j, k] != int.MaxValue)
                    continue;

                if (arr[j, i] == arr[i, k])
                {
                    arr[j, k] = arr[j, i];
                }
            }
        }
    }
}
bool CanKnowRanking_Func(int index)
{
    bool _canKnowRanking = true;

    for (int i = 1; i < n + 1; i++)
    {
        if (arr[index, i] == int.MaxValue)
        {
            _canKnowRanking = false;
            break;
        }
    }

    return _canKnowRanking;
}
int GetStudentCnt_Fun()
{
    int _cnt = 0;

    for (int i = 1; i < n + 1; i++)
    {
        if (CanKnowRanking_Func(i))
        {
            _cnt++;
        }
    }

    return _cnt;
}