StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int w = input[0];
int h = input[1];

string str = null;
int[,] map = new int[h, w];
List<Info> raserList = new List<Info>();

for (int i = 0; i < h; i++)
{
    str = sr.ReadLine();
    for (int j = 0; j < w; j++)
    {
        if (str[j].ToString() == ".")
        {
            map[i, j] = int.MaxValue;
        }
        else if (str[j].ToString() == "*")
        {
            map[i, j] = -1;
        }
        else if (str[j].ToString() == "C")
        {
            raserList.Add(new Info(i, j));
        }
    }
}

for (int i = 0; i < raserList.Count; i++)
{
    if (i == 0)
    {
        map[raserList[i].y, raserList[i].x] = 0;
    }
    else
    {
        map[raserList[i].y, raserList[i].x] = int.MaxValue;
    }
}

int result = 0;

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

BFS(raserList[0].y, raserList[0].x);
sw.WriteLine(result);
sw.Flush();
sw.Close();

void BFS(int _startY, int _startX)
{
    int[,] arr = new int[h, w];
    Queue<Info> q = new Queue<Info>();
    q.Enqueue(new Info(_startY, _startX)); // 시작 : 0, 위 : 1, 아래 : 2, 왼 : 3, 오른 : 4
    arr[_startY, _startX] = 0;

    Info temp = null;
    int ny = 0;
    int nx = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= h || nx >= w)
                continue;

            if (map[ny, nx] == -1)
                continue;

            if (map[ny, nx] == int.MaxValue)
            {
                if (arr[temp.y, temp.x] == 0)
                {
                    map[ny, nx] = 0;
                    arr[ny, nx] = 1 << (i + 1);
                }
                else
                {
                    if ((arr[temp.y, temp.x] & (1 << (i + 1))) == 0)
                    {
                        map[ny, nx] = map[temp.y, temp.x] + 1;
                        arr[ny, nx] = 1 << (i + 1);
                    }
                    else
                    {
                        map[ny, nx] = map[temp.y, temp.x];
                        arr[ny, nx] = 1 << (i + 1);
                    }
                }

                q.Enqueue(new Info(ny, nx));
            }
            else
            {
                if ((arr[temp.y, temp.x] & (1 << (i + 1))) == 0)
                {
                    if (map[ny, nx] > map[temp.y, temp.x] + 1)
                    {
                        map[ny, nx] = map[temp.y, temp.x] + 1;
                        arr[ny, nx] = 1 << (i + 1);
                        q.Enqueue(new Info(ny, nx));
                    }
                    else if (map[ny, nx] == map[temp.y, temp.x] + 1)
                    {
                        arr[ny, nx] |= 1 << (i + 1);
                    }
                }
                else
                {
                    if (map[ny, nx] > map[temp.y, temp.x])
                    {
                        map[ny, nx] = map[temp.y, temp.x];
                        arr[ny, nx] = 1 << (i + 1);
                        q.Enqueue(new Info(ny, nx));
                    }
                    else if (map[ny, nx] == map[temp.y, temp.x])
                    {
                        arr[ny, nx] |= 1 << (i + 1);
                    }

                }
            }

        }
    }

    result = map[raserList[1].y, raserList[1].x];
}

class Info
{
    public int y;
    public int x;

    public Info(int _y, int _x)
    {
        this.y = _y;
        this.x = _x;
    }
}