StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
string input = null;
int w = 0;
int h = 0;
int[,] arr = null;
objectInfo humanInfo = null;
List<objectInfo> fireInfo = null;
int result = -1;

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

for (int i = 0; i < t; i++)
{
    Input();
    MoveFireAndHuman();
    Print();
}

sw.Flush();
sw.Close();

void Input()
{
    input = sr.ReadLine();
    int[] temp = Array.ConvertAll(input.Split(), int.Parse);
    w = temp[0];
    h = temp[1];
    arr = new int[h, w];
    fireInfo = new List<objectInfo>();

    for (int i = 0; i < h; i++)
    {
        input = sr.ReadLine();
        for (int j = 0; j < w; j++)
        {
            if (input[j].ToString() == "#")
            {
                arr[i, j] = int.MaxValue;
            }
            else if (input[j].ToString() == ".")
            {
                arr[i, j] = 0;
            }
            else if (input[j].ToString() == "@")
            {
                arr[i, j] = 1;
                humanInfo = new objectInfo(i, j, false);
            }
            else if (input[j].ToString() == "*")
            {
                arr[i, j] = -1;
                fireInfo.Add(new objectInfo(i, j, true));
            }
        }
    }
}
void MoveFireAndHuman()
{
    Queue<objectInfo> q = new Queue<objectInfo>();

    for (int i = 0; i < fireInfo.Count; i++)
    {
        q.Enqueue(new objectInfo(fireInfo[i].y, fireInfo[i].x, fireInfo[i].isFire));
    }

    q.Enqueue(new objectInfo(humanInfo.y, humanInfo.x, humanInfo.isFire));

    objectInfo temp = null;
    int ny = 0;
    int nx = 0;

    result = -1;

    if (humanInfo.y == 0 || humanInfo.x == 0 || humanInfo.y == h - 1 || humanInfo.x == w - 1)
    {
        result = 1;
        return;
    }

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny > h - 1 || nx > w - 1)
            {
                continue;
            }

            if (arr[ny, nx] == int.MaxValue)
            {
                continue;
            }


            if (arr[ny, nx] == 0)
            {
                if (temp.isFire)
                {
                    arr[ny, nx] = arr[temp.y, temp.x] - 1;
                }
                else
                {
                    arr[ny, nx] = arr[temp.y, temp.x] + 1;
                    if (ny == 0 || nx == 0 || ny == h - 1 || nx == w - 1)
                    {
                        if (result == -1)
                        {
                            result = arr[ny, nx];
                        }
                        else
                        {
                            result = Math.Min(result, arr[ny, nx]);
                        }
                    }
                }

                q.Enqueue(new objectInfo(ny, nx, temp.isFire));
            }

        }
    }
}
void Print()
{
    if (result == -1)
    {
        sw.WriteLine("IMPOSSIBLE");
    }
    else
    {
        sw.WriteLine(result);
    }
}

class objectInfo
{
    public int y;
    public int x;
    public bool isFire;

    public objectInfo(int y, int x, bool isFire)
    {
        this.y = y;
        this.x = x;
        this.isFire = isFire;
    }
}