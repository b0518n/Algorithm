StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int y1 = input[0];
int x1 = input[1];

int y2 = input[2];
int x2 = input[3];

int[,] classRoom = new int[n + 1, m + 1];
int[,] arr = new int[n + 1, m + 1];

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

InitArr_Fun();
InitClassRoom_Fun();
Input_Func();

BFS(y1, x1);
sw.WriteLine(arr[y2, x2]);
sw.Flush();
sw.Close();

void InitArr_Fun()
{
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < m + 1; j++)
        {
            arr[i, j] = int.MaxValue;
        }
    }
}
void InitClassRoom_Fun()
{
    for (int i = 0; i < n + 1; i++)
    {
        classRoom[i, 0] = int.MaxValue;
    }

    for (int i = 0; i < m + 1; i++)
    {
        classRoom[0, i] = int.MaxValue;
    }
}
void Input_Func()
{
    string str = string.Empty;
    for (int i = 1; i < n + 1; i++)
    {
        str = sr.ReadLine();
        for (int j = 0; j < m; j++)
        {
            if (str[j].ToString() == "#")
            {
                classRoom[i, j + 1] = -1;
            }
            else if (str[j].ToString() == "*")
            {
                classRoom[i, j + 1] = 0;
            }
            else
            {
                classRoom[i, j + 1] = int.Parse(str[j].ToString());
            }
        }
    }
}
void BFS(int _y, int _x)
{
    Queue<PosInfo> q = new Queue<PosInfo>();
    q.Enqueue(new PosInfo(_y, _x, 0, false));

    PosInfo temp;
    int ny = 0;
    int nx = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny <= 0 || nx <= 0 || ny > n || nx > m)
                continue;
            if (arr[ny, nx] == int.MaxValue)
            {
                if (classRoom[ny, nx] == 1)
                {
                    if (temp.isEmpty == false)
                    {
                        arr[ny, nx] = temp.cnt + 1;
                        q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], false));
                    }
                    else
                    {
                        arr[ny, nx] = temp.cnt;
                        q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], false));
                    }
                }
                else
                {
                    if (temp.isEmpty == false)
                    {
                        arr[ny, nx] = temp.cnt + 1;
                        q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], true));
                    }
                    else
                    {
                        arr[ny, nx] = temp.cnt;
                        q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], true));
                    }
                }
            }
            else
            {
                if (temp.isEmpty)
                {
                    if (arr[ny, nx] > temp.cnt)
                    {
                        arr[ny, nx] = temp.cnt;
                        if (classRoom[ny, nx] == 1)
                        {
                            q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], false));
                        }
                        else
                        {
                            q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], true));
                        }
                    }
                }
                else
                {
                    if (arr[ny, nx] > temp.cnt + 1)
                    {
                        arr[ny, nx] = temp.cnt + 1;
                        if (classRoom[ny, nx] == 1)
                        {
                            q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], false));
                        }
                        else
                        {
                            q.Enqueue(new PosInfo(ny, nx, arr[ny, nx], true));
                        }
                    }
                }
            }

        }
    }
}

class PosInfo
{
    public int y;
    public int x;
    public int cnt;
    public bool isEmpty;

    public PosInfo(int _y, int _x, int _cnt, bool _isEmpty)
    {
        this.y = _y;
        this.x = _x;
        this.cnt = _cnt;
        this.isEmpty = _isEmpty;
    }
}