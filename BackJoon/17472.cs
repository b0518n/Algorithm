int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] rows = null;
int[,] dp = new int[n, m];
int[,] visited = new int[n, m];

int number = 1;

for (int i = 0; i < n; i++)
{
    rows = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < rows.Length; j++)
    {
        dp[i, j] = rows[j];
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (dp[i, j] == 1 && visited[i, j] == 0)
        {
            BFS(i, j, dp, visited, n, m, number);
            number++;
        }
    }
}

int[] parent = new int[number];
List<int[]> list = new List<int[]>();

for (int i = 1; i < number; i++)
{
    parent[i] = i;
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (dp[i, j] != 0)
        {
            SearchRoute(i, j, visited, 0, n, m, visited[i, j], list);
            SearchRoute(i, j, visited, 1, n, m, visited[i, j], list);
            SearchRoute(i, j, visited, 2, n, m, visited[i, j], list);
            SearchRoute(i, j, visited, 3, n, m, visited[i, j], list);
        }
    }
}

list = list.OrderBy(arr => arr[2]).ToList();
int length = 0;

for (int i = 0; i < list.Count; i++)
{
    if (Merge(list[i][0], list[i][1], parent))
    {
        length += list[i][2];
    }
}

bool isConnected = true;
int temp = Find(1, parent);

for (int i = 2; i < parent.Length; i++)
{
    if (temp != Find(i, parent))
    {
        isConnected = false;
        break;
    }
}

if (isConnected)
{
    Console.WriteLine(length);
}
else
{
    Console.WriteLine(-1);
}

void SearchRoute(int y, int x, int[,] visited, int direction, int n, int m, int number, List<int[]> list)
{
    int[] dy = new int[4] { 1, -1, 0, 0 };
    int[] dx = new int[4] { 0, 0, 1, -1 };

    Queue<int[]> q = new Queue<int[]>();
    q.Enqueue(new int[2] { y, x });

    int[] temp = null;
    int ny = 0;
    int nx = 0;

    int length = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        ny = temp[0] + dy[direction];
        nx = temp[1] + dx[direction];

        if (ny >= 0 && ny < n && nx >= 0 && nx < m)
        {
            if (visited[ny, nx] != number)
            {
                if (visited[ny, nx] == 0)
                {
                    q.Enqueue(new int[2] { ny, nx });
                    length++;
                }
                else
                {
                    if (length >= 2)
                    {
                        list.Add(new int[3] { number, visited[ny, nx], length });
                    }
                }
            }
        }
    }
}

void BFS(int y, int x, int[,] dp, int[,] visited, int n, int m, int number)
{
    int[] dy = new int[4] { 1, -1, 0, 0 };
    int[] dx = new int[4] { 0, 0, 1, -1 };

    int ny = 0;
    int nx = 0;

    Queue<int[]> q = new Queue<int[]>();
    visited[y, x] = number;
    q.Enqueue(new int[2] { y, x });

    int[] temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= m)
            {
                continue;
            }

            if (dp[ny, nx] == 0)
            {
                continue;
            }

            if (visited[ny, nx] != 0)
            {
                continue;
            }

            visited[ny, nx] = number;
            q.Enqueue(new int[2] { ny, nx });
        }
    }
}

int Find(int x, int[] parent)
{
    while (x != parent[x])
    {
        x = parent[x];
    }

    return x;
}

bool Merge(int x, int y, int[] parent)
{
    int _x = Find(x, parent);
    int _y = Find(y, parent);

    if (_x == _y)
    {
        return false;
    }

    if (_x > _y)
    {
        parent[_x] = _y;
    }
    else
    {
        parent[_y] = _x;
    }

    return true;
}