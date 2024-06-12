StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
string input = string.Empty;
int[,] roomArr = new int[n, n];
int[,] arr = new int[n, n];

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { -1, 1, 0, 0 };

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        arr[i, j] = int.MaxValue;
    }
}

arr[0, 0] = 0;

for (int i = 0; i < n; i++)
{
    input = sr.ReadLine();
    for (int j = 0; j < n; j++)
    {
        roomArr[i, j] = int.Parse(input[j].ToString());
    }
}

BFS();
sw.WriteLine(arr[n - 1, n - 1]);
sw.Flush();
sw.Close();

void BFS()
{
    Queue<Info> q = new Queue<Info>();
    q.Enqueue(new Info(0, 0));
    arr[0, 0] = 0;

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

            if (ny < 0 || nx < 0 || ny >= n || nx >= n)
            {
                continue;
            }

            if (arr[ny, nx] == int.MaxValue)
            {
                if (roomArr[ny, nx] == 0)
                    arr[ny, nx] = arr[temp.y, temp.x] + 1;
                else
                    arr[ny, nx] = arr[temp.y, temp.x];
                q.Enqueue(new Info(ny, nx));
            }
            else
            {
                if (roomArr[ny, nx] == 0)
                {
                    if (arr[ny, nx] > arr[temp.y, temp.x] + 1)
                    {
                        arr[ny, nx] = arr[temp.y, temp.x] + 1;
                        q.Enqueue(new Info(ny, nx));
                    }
                }
                else
                {
                    if (arr[ny, nx] > arr[temp.y, temp.x])
                    {
                        arr[ny, nx] = arr[temp.y, temp.x];
                        q.Enqueue(new Info(ny, nx));
                    }
                }
            }
        }
    }
}

class Info
{
    public int y;
    public int x;

    public Info(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}