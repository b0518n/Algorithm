int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int r = input[0];
int c = input[1];

string str = null;
string[,] maze = new string[r, c];
Data sData = null; // 지훈이의 위치
List<Data> fDataList = new List<Data>(); // 불 위치

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
int[,] arr = new int[r, c];
int result = -1;

for (int i = 0; i < r; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < c; j++)
    {
        maze[i, j] = str[j].ToString();
        if (maze[i, j] == "J")
        {
            sData = new Data(i, j);
        }
        else if (maze[i, j] == "F")
        {
            fDataList.Add(new Data(i, j));
        }
    }
}

foreach (Data data in fDataList)
{
    MoveFire(data.y, data.x);
}

MoveJiHoon(sData.y, sData.x);
if (result == -1)
{
    Console.WriteLine("IMPOSSIBLE");
}
else
{
    Console.WriteLine(result);
}


void MoveFire(int y, int x)
{
    Queue<Data> q = new Queue<Data>();
    q.Enqueue(new Data(y, x));
    int[,] visited = new int[r, c];
    visited[y, x] = 1;
    int ny = 0;
    int nx = 0;
    Data temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= r || nx >= c || visited[ny, nx] == 1 || maze[ny, nx] == "#" || maze[ny, nx] == "F")
            {
                continue;
            }

            if (arr[ny, nx] == 0)
            {
                q.Enqueue(new Data(ny, nx));
                visited[ny, nx] = 1;
                arr[ny, nx] = arr[temp.y, temp.x] + 1;
            }
            else
            {
                if (arr[ny, nx] > arr[temp.y, temp.x] + 1)
                {
                    q.Enqueue(new Data(ny, nx));
                    visited[ny, nx] = 1;
                    arr[ny, nx] = arr[temp.y, temp.x] + 1;
                }
            }
        }
    }
}
void MoveJiHoon(int y, int x)
{
    Queue<Data> q = new Queue<Data>();
    q.Enqueue(new Data(y, x));
    int[,] visited = new int[r, c];
    visited[y, x] = 1;
    int ny = 0;
    int nx = 0;
    Data temp = null;
    int time = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        time = temp.time;

        if (temp.y == 0 || temp.x == 0 || temp.y == r - 1 || temp.x == c - 1)
        {
            result = time + 1;
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= r || nx >= c || maze[ny, nx] == "#" || maze[ny, nx] == "F" || visited[ny, nx] == 1)
            {
                continue;
            }

            if (arr[ny, nx] == 0)
            {
                q.Enqueue(new Data(ny, nx, time + 1));
                visited[ny, nx] = 1;
                continue;
            }

            if (time + 1 < arr[ny, nx])
            {
                q.Enqueue(new Data(ny, nx, time + 1));
                visited[ny, nx] = 1;
                continue;
            }
        }
    }
}

class Data
{
    public int y;
    public int x;
    public int time;

    public Data(int y, int x, int time = 0)
    {
        this.y = y;
        this.x = x;
        this.time = time;
    }
}