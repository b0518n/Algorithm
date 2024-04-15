StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string input = null;
int[,] arr = null;

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

int result = 0;
bool isChanged = true;

Dictionary<string, int> visited = new Dictionary<string, int>();

Input();
while (isChanged)
{
    isChanged = false;
    CheckIsFallDown();
    visited = new Dictionary<string, int>();
    CheckAdjacentZones();
}
Print();

void Input()
{
    arr = new int[12, 6];

    for (int i = 0; i < 12; i++)
    {
        input = sr.ReadLine();
        for (int j = 0; j < 6; j++)
        {
            if (input[j].ToString() == ".")
            {
                arr[i, j] = 0;
            }
            else if (input[j].ToString() == "R")
            {
                arr[i, j] = 1;
            }
            else if (input[j].ToString() == "G")
            {
                arr[i, j] = 2;
            }
            else if (input[j].ToString() == "B")
            {
                arr[i, j] = 3;
            }
            else if (input[j].ToString() == "P")
            {
                arr[i, j] = 4;
            }
            else if (input[j].ToString() == "Y")
            {
                arr[i, j] = 5;
            }
        }
    }
}
void CheckAdjacentZones()
{
    for (int i = 11; i >= 0; i--)
    {
        for (int j = 0; j < 6; j++)
        {
            if (arr[i, j] == 0 || visited.ContainsKey($"{i} {j}"))
            {
                continue;
            }

            Bomb(i, j);
        }
    }

    if (isChanged)
    {
        result++;
    }
}
void CheckIsFallDown()
{
    for (int i = 10; i >= 0; i--)
    {
        for (int j = 0; j < 6; j++)
        {
            if (arr[i, j] == 0)
            {
                continue;
            }

            FallDown(i, j);
        }
    }
}
void FallDown(int y, int x)
{
    Queue<PositionInfo> q = new Queue<PositionInfo>();
    q.Enqueue(new PositionInfo(y, x));

    int ny = 0;
    int nx = 0;
    PositionInfo temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        ny = temp.y + 1;
        nx = temp.x;

        if (ny > 11 || arr[ny, nx] != 0)
        {
            continue;
        }

        arr[ny, nx] = arr[temp.y, temp.x];
        arr[temp.y, temp.x] = 0;
        q.Enqueue(new PositionInfo(ny, nx));
    }
}
void Bomb(int y, int x)
{
    Queue<PositionInfo> q = new Queue<PositionInfo>();
    q.Enqueue(new PositionInfo(y, x));

    PositionInfo temp = null;
    int ny = 0;
    int nx = 0;

    List<PositionInfo> list = new List<PositionInfo>();
    list.Add(new PositionInfo(y, x));
    visited.Add($"{y} {x}", 1);

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny > 11 || nx > 5 || visited.ContainsKey($"{ny} {nx}"))
            {
                continue;
            }

            if (arr[ny, nx] != arr[temp.y, temp.x])
            {
                continue;
            }

            list.Add(new PositionInfo(ny, nx));
            q.Enqueue(new PositionInfo(ny, nx));
            visited.Add($"{ny} {nx}", 1);
        }
    }

    if (list.Count >= 4)
    {
        foreach (PositionInfo position in list)
        {
            arr[position.y, position.x] = 0;
        }

        isChanged = true;
    }

}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}

class PositionInfo
{
    public int y;
    public int x;

    public PositionInfo(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}