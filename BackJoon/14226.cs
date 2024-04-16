StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int s = 0;
int screenCnt = 1;
int clipBoardCnt = 0;
int time = 0;

Dictionary<int, int> dp = new Dictionary<int, int>();
int result = 0;

Input();
BFS();
Print();

void Input()
{
    s = int.Parse(sr.ReadLine());
}
void BFS()
{
    Queue<DataInfo> q = new Queue<DataInfo>();
    q.Enqueue(new DataInfo(1, 0, 0));

    DataInfo temp = null;
    int _screenCnt = 0;
    int _clipBoardCnt = 0;
    int _time = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        // 1번
        _screenCnt = temp.screenCnt;
        _clipBoardCnt = temp.screenCnt;
        _time = temp.time + 1;

        if (_screenCnt == s)
        {
            result = _time;
            break;
        }

        if (!dp.ContainsKey($"{_screenCnt} {_clipBoardCnt}".GetHashCode()))
        {
            dp.Add($"{_screenCnt} {_clipBoardCnt}".GetHashCode(), _time);
            q.Enqueue(new DataInfo(_screenCnt, _clipBoardCnt, _time));
        }
        else
        {
            if (dp[$"{_screenCnt} {_clipBoardCnt}".GetHashCode()] > dp[$"{temp.screenCnt} {temp.clipBoardCnt}".GetHashCode()] + 1)
            {
                dp[$"{_screenCnt} {_clipBoardCnt}".GetHashCode()] = dp[$"{temp.screenCnt} {temp.clipBoardCnt}".GetHashCode()] + 1;
                q.Enqueue(new DataInfo(_screenCnt, _clipBoardCnt, _time));
            }
        }

        // 2번
        _screenCnt = temp.screenCnt + temp.clipBoardCnt;
        _clipBoardCnt = temp.clipBoardCnt;
        _time = temp.time + 1;

        if (_screenCnt == s)
        {
            result = _time;
            break;
        }

        if (_screenCnt <= 1025)
        {
            if (!dp.ContainsKey($"{_screenCnt} {_clipBoardCnt}".GetHashCode()))
            {
                dp.Add($"{_screenCnt} {_clipBoardCnt}".GetHashCode(), _time);
                q.Enqueue(new DataInfo(_screenCnt, _clipBoardCnt, _time));
            }
            else
            {
                if (dp[$"{_screenCnt} {_clipBoardCnt}".GetHashCode()] > dp[$"{temp.screenCnt} {temp.clipBoardCnt}".GetHashCode()] + 1)
                {
                    dp[$"{_screenCnt} {_clipBoardCnt}".GetHashCode()] = dp[$"{temp.screenCnt} {temp.clipBoardCnt}".GetHashCode()] + 1;
                    q.Enqueue(new DataInfo(_screenCnt, _clipBoardCnt, _time));
                }
            }
        }

        // 3번
        _screenCnt = temp.screenCnt - 1;
        _clipBoardCnt = temp.clipBoardCnt;
        _time = temp.time + 1;

        if (_screenCnt == s)
        {
            result = _time;
            break;
        }

        if (_screenCnt >= 0)
        {
            if (!dp.ContainsKey($"{_screenCnt} {_clipBoardCnt}".GetHashCode()))
            {
                dp.Add($"{_screenCnt} {_clipBoardCnt}".GetHashCode(), _time);
                q.Enqueue(new DataInfo(_screenCnt, _clipBoardCnt, _time));
            }
            else
            {
                if (dp[$"{_screenCnt} {_clipBoardCnt}".GetHashCode()] > dp[$"{temp.screenCnt} {temp.clipBoardCnt}".GetHashCode()] + 1)
                {
                    dp[$"{_screenCnt} {_clipBoardCnt}".GetHashCode()] = dp[$"{temp.screenCnt} {temp.clipBoardCnt}".GetHashCode()] + 1;
                    q.Enqueue(new DataInfo(_screenCnt, _clipBoardCnt, _time));
                }
            }
        }
    }
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}

class DataInfo
{
    public int screenCnt;
    public int clipBoardCnt;
    public int time;

    public DataInfo(int screenCnt, int clipBoardCnt, int time)
    {
        this.screenCnt = screenCnt;
        this.clipBoardCnt = clipBoardCnt;
        this.time = time;
    }
}