StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[,] arr = new int[n, n];

Input_Func();
SearchTwoFriend_Func();
sw.WriteLine(GetMostPopularFriendCnt_Fun());
sw.Flush();
sw.Close();

void Input_Func()
{
    string input = string.Empty;

    for (int i = 0; i < n; i++)
    {
        input = sr.ReadLine();
        for (int j = 0; j < n; j++)
        {
            if (i == j)
                continue;

            if (input[j].ToString() == "N")
            {
                arr[i, j] = int.MaxValue;
            }
            else
            {
                arr[i, j] = 1;
            }
        }
    }
}
void SearchTwoFriend_Func()
{
    for (int i = 0; i < n; i++) // 중간
    {
        for (int j = 0; j < n; j++) // 시작
        {
            if (i == j)
                continue;
            if (arr[j, i] == int.MaxValue || arr[j, i] == 2)
                continue;

            for (int k = 0; k < n; k++) // 끝
            {
                if (i == k)
                    continue;
                if (arr[i, k] == int.MaxValue || arr[i, k] == 2)
                    continue;

                if (arr[j, k] == int.MaxValue)
                    arr[j, k] = 2;
            }
        }
    }
}
int GetMostPopularFriendCnt_Fun()
{
    int _friendCnt = -1;
    int _cnt = 0;

    for (int i = 0; i < n; i++)
    {
        _cnt = 0;
        for (int j = 0; j < n; j++)
        {
            if (arr[i, j] == 1 || arr[i, j] == 2)
                _cnt++;
        }

        if (_friendCnt == -1)
        {
            _friendCnt = _cnt;
        }
        else
        {
            _friendCnt = Math.Max(_friendCnt, _cnt);
        }
    }

    return _friendCnt;
}