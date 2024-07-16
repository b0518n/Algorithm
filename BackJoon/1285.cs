sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
string str = null;

int[,] arr = new int[n, n];
List<int> tempList = new List<int>();

for (int i = 0; i < n; i++)
{
    str = sr.ReadLine();
    for (int j = 0; j < n; j++)
    {
        if (str[j].ToString() == "H")
        {
            arr[i, j] = 1;
        }
        else
        {
            arr[i, j] = -1;
        }
    }
}

int result = int.MaxValue;
CheckCase(0);

sw.WriteLine(result);
sw.Flush();

// 0 : 뒤집기 x , 1 : 뒤집기 o
void CheckCase(int _y)
{
    if (_y == n)
    {
        result = Math.Min(result, GetMinTailCnt());
        return;
    }

    for (int i = 0; i < 2; i++)
    {
        tempList.Add(i);
        CheckCase(_y + 1);
        tempList.RemoveAt(tempList.Count - 1);
    }
}
int GetMinTailCnt()
{
    int _headCnt = 0;
    int _tailCnt = 0;
    int _retValue = 0;

    for (int i = 0; i < n; i++)
    {
        _headCnt = 0;
        _tailCnt = 0;
        for (int j = 0; j < n; j++)
        {
            if ((arr[i, j] == 1 && tempList[j] == 0) || (arr[i, j] == -1 && tempList[j] == 1))
            {
                _headCnt++;
            }
            else
            {
                _tailCnt++;
            }
        }

        _retValue += Math.Min(_headCnt, _tailCnt);
    }

    return _retValue;
}