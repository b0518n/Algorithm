int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 세로
int m = input[1]; // 가로
int k = input[2]; // 음식물 쓰레기의 개수
int[,] arr = new int[n, m];
int[,] visited = new int[n, m];

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
int result = -1;

// 1 : 음식물 쓰레기
for (int i = 0; i < k; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    arr[input[0] - 1, input[1] - 1] = 1;
}

SearchTrash();
Console.WriteLine(result);

void SearchTrash()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (arr[i, j] == 0 || visited[i, j] == 1)
            {
                continue;
            }

            if (k > 0)
            {
                MergeTrash(i, j);
            }
        }
    }
}

void MergeTrash(int y, int x)
{
    Queue<TrashInfo> q = new Queue<TrashInfo>();
    q.Enqueue(new TrashInfo(y, x));
    visited[y, x] = 1;
    int ny = 0;
    int nx = 0;
    TrashInfo temp = null;
    int cnt = 1;
    k--;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= m || visited[ny, nx] == 1 || arr[ny, nx] == 0)
            {
                continue;
            }

            q.Enqueue(new TrashInfo(ny, nx));
            visited[ny, nx] = 1;
            cnt++;
            k--;
        }
    }

    if (result == -1)
    {
        result = cnt;
    }
    else
    {
        result = Math.Max(result, cnt);
    }
}

class TrashInfo
{
    public int y;
    public int x;

    public TrashInfo(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}