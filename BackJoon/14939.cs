StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


int[,] arr = new int[10, 10];
string str = string.Empty;
int result = -1;

for (int i = 0; i < 10; i++)
{
    str = sr.ReadLine();
    for (int j = 0; j < 10; j++)
    {
        if (str[j].ToString() == "#")
        {
            arr[i, j] = 0;
        }
        else
        {
            arr[i, j] = 1;
        }
    }
}

List<int> tempList = new List<int>();
SelectCase();
sw.WriteLine(result);
sw.Flush();
sw.Close();

void SelectCase()
{
    if (tempList.Count == 10)
    {
        MinClickBtnCnt();
    }
    else
    {
        for (int i = 0; i < 2; i++)
        {
            tempList.Add(i);
            SelectCase();
            tempList.RemoveAt(tempList.Count - 1);
        }
    }
}
void MinClickBtnCnt()
{
    int cnt = 0;

    int[,] arr = CopyArr();
    for (int i = 0; i < 10; i++)
    {
        if (tempList[i] == 1)
        {
            TurnOnOrOff(0, i, ref arr);
            cnt++;
        }
    }

    for (int i = 1; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            if (arr[i - 1, j] == 1)
            {
                TurnOnOrOff(i, j, ref arr);
                cnt++;
            }
        }
    }

    bool isTurnedOn = false;

    for (int i = 0; i < 10; i++)
    {
        if (isTurnedOn)
            break;

        for (int j = 0; j < 10; j++)
        {
            if (arr[i, j] == 1)
            {
                isTurnedOn = true;
                break;
            }
        }
    }

    if (!isTurnedOn)
    {
        if (result == -1)
        {
            result = cnt;
        }
        else
        {
            result = Math.Min(result, cnt);
        }
    }
}
int[,] CopyArr()
{
    int[,] tempArr = new int[10, 10];

    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            tempArr[i, j] = arr[i, j];
        }
    }

    return tempArr;
}
void TurnOnOrOff(int _y, int _x, ref int[,] _arr)
{
    int[] dy = new int[4] { -1, 1, 0, 0 };
    int[] dx = new int[4] { 0, 0, -1, 1 };

    int ny = 0;
    int nx = 0;

    for (int i = 0; i < 4; i++)
    {
        ny = _y + dy[i];
        nx = _x + dx[i];

        if (ny < 0 || nx < 0 || ny >= 10 || nx >= 10)
        {
            continue;
        }

        if (_arr[ny, nx] == 0)
        {
            _arr[ny, nx] = 1;
        }
        else
        {
            _arr[ny, nx] = 0;
        }
    }

    if (_arr[_y, _x] == 1)
    {
        _arr[_y, _x] = 0;
    }
    else
    {
        _arr[_y, _x] = 1;
    }
}