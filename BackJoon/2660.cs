StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] input = null;
int[,] arr = new int[n + 1, n + 1];

InitArr_Func();
Input_Func();
Floyd_Warshall_Func();
BruteForce_Func();


void InitArr_Func()
{
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (i == j)
            {
                continue;
            }

            arr[i, j] = int.MaxValue;
        }
    }
}
void Input_Func()
{
    while (true)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        if (input[0] == -1 && input[1] == -1)
            break;

        arr[input[0], input[1]] = 1;
        arr[input[1], input[0]] = 1;
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
                if (arr[i, k] == int.MaxValue)
                    continue;

                if (arr[j, k] == int.MaxValue)
                {
                    arr[j, k] = arr[j, i] + arr[i, k];
                }
                else
                {
                    arr[j, k] = Math.Min(arr[j, k], arr[j, i] + arr[i, k]);
                }
            }
        }
    }
}
void BruteForce_Func()
{
    int _min = 0;
    List<int> _list = new List<int>();
    int _value = 0;

    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (i == j)
                continue;
            if (_value == 0)
            {
                _value = arr[i, j];
            }
            else
            {
                _value = Math.Max(_value, arr[i, j]);
            }
        }

        if (_min == 0)
        {
            _min = _value;
            _list.Add(i);
        }
        else
        {
            if (_min > _value)
            {
                _min = _value;
                _list.Clear();
                _list.Add(i);
            }
            else if (_min == _value)
            {
                _list.Add(i);
            }
        }

        _value = 0;
    }

    _list.Sort();
    Print_Func(_min, _list.Count, _list);
}
void Print_Func(int _value, int _cnt, List<int> _list)
{
    sw.WriteLine($"{_value} {_cnt}");
    sw.WriteLine(string.Join(" ", _list));
    sw.Flush();
    sw.Close();
}