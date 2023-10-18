int n = int.Parse(Console.ReadLine());
int[,] dp = new int[n, n];
int[,] distances = null;
int[,] visited = null;

int[] input = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        dp[i, j] = input[j];
    }
}

int size = 2;
int count = 0;
int distance = int.MaxValue;
int y = -1;
int x = -1;
int result = 0;

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { 1, -1, 0, 0 };

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (dp[i, j] == 9)
        {
            y = i;
            x = j;
        }
    }
}

while (true)
{
    if (BFS(y, x) == -1)
    {
        break;
    }
}

Console.WriteLine(result);

int BFS(int _y, int _x)
{
    visited = new int[n, n];
    distances = new int[n, n];
    distance = int.MaxValue;

    Queue<int[]> queue = new Queue<int[]>();
    queue.Enqueue(new int[2] { _y, _x });
    visited[_y, _x] = 1;
    int[] temp = null;

    int ny = 0;
    int nx = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= n)
            {
                continue;
            }

            if (dp[ny, nx] > size)
            {
                continue;
            }

            if (visited[ny, nx] == 1)
            {
                continue;
            }

            visited[ny, nx] = 1;
            distances[ny, nx] = distances[temp[0], temp[1]] + 1;
            queue.Enqueue(new int[2] { ny, nx });

            if (dp[ny, nx] < size && dp[ny, nx] != 0)
            {
                if (distance > distances[ny, nx])
                {
                    distance = distances[ny, nx];
                    y = ny;
                    x = nx;
                }
                else if (distance == distances[ny, nx])
                {
                    if (y > ny)
                    {
                        y = ny;
                        x = nx;
                    }
                    else if (y == ny)
                    {
                        if (x > nx)
                        {
                            x = nx;
                        }
                    }
                }
            }
        }
    }

    if (distance == int.MaxValue)
    {
        return -1;
    }
    else
    {
        dp[y, x] = 9;
        dp[_y, _x] = 0;
        result += distance;
        count++;
        if (size == count)
        {
            size++;
            count = 0;
        }
    }

    return 1;
}