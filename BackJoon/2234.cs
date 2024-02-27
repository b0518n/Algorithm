StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] arr = new int[m, n];
int[] dy = new int[4] { 0, -1, 0, 1 };
int[] dx = new int[4] { -1, 0, 1, 0 };

int output_1 = 0;
int output_2 = int.MinValue;
int output_3 = 0;

List<int> list = new List<int>();
list.Add(0);

Input();
BruteForce();
Dictionary<int, int>[] _arr = new Dictionary<int, int>[list.Count];
for (int i = 0; i < _arr.Length; i++)
{
    _arr[i] = new Dictionary<int, int>();
}

GetAdjacentRoom(0, 0);
CalculateOutput_3();
if (output_3 == int.MinValue)
{
    output_3 = output_2;
}

sw.WriteLine(output_1);
sw.WriteLine(output_2);
sw.WriteLine(output_3);
sw.Close();


void Input()
{
    for (int i = 0; i < m; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (int j = 0; j < n; j++)
        {
            arr[i, j] = input[j];
        }
    }
}

void SeperateRoomAndGetSize(int y, int x, ref int number)
{
    Queue<PositionInfo> q = new Queue<PositionInfo>();
    q.Enqueue(new PositionInfo(y, x));
    int[,] visited = new int[m, n];
    visited[y, x] = 1;


    int ny = 0;
    int nx = 0;
    PositionInfo temp = null;

    int size = 1;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= m || nx >= n)
            {
                continue;
            }

            if ((arr[temp.y, temp.x] & (1 << i)) == 0 && visited[ny, nx] == 0)
            {
                size++;
                q.Enqueue(new PositionInfo(ny, nx));
                visited[ny, nx] = 1;
            }
        }

        arr[temp.y, temp.x] = number;
    }

    output_2 = Math.Max(output_2, size);
    list.Add(size);
    number--;
}

void BruteForce()
{
    int number = -1;

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (arr[i, j] >= 0)
            {
                SeperateRoomAndGetSize(i, j, ref number);
            }
        }
    }

    output_1 = (number + 1) * (-1);
}

void GetAdjacentRoom(int y, int x)
{
    Queue<PositionInfo> q = new Queue<PositionInfo>();
    q.Enqueue(new PositionInfo(y, x));
    int[,] visited = new int[m, n];
    visited[y, x] = 1;

    int ny = 0;
    int nx = 0;
    PositionInfo temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= m || nx >= n || visited[ny, nx] == 1)
            {
                continue;
            }

            q.Enqueue(new PositionInfo(ny, nx));
            visited[ny, nx] = 1;
            if (arr[temp.y, temp.x] != arr[ny, nx])
            {
                if (!_arr[arr[temp.y, temp.x] * (-1)].ContainsKey(arr[ny, nx] * (-1)))
                {
                    _arr[arr[temp.y, temp.x] * (-1)].Add(arr[ny, nx] * (-1), 1);
                }

                if (!_arr[arr[ny, nx] * (-1)].ContainsKey(arr[temp.y, temp.x] * (-1)))
                {
                    _arr[arr[ny, nx] * (-1)].Add(arr[temp.y, temp.x] * (-1), 1);
                }
            }
        }
    }

}

void CalculateOutput_3()
{
    int max = int.MinValue;

    for (int i = 1; i < _arr.Length; i++)
    {
        foreach (int key in _arr[i].Keys)
        {
            max = Math.Max(max, list[key] + list[i]);
        }
    }

    output_3 = max;
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