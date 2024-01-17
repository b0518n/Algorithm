int n = int.Parse(Console.ReadLine());
int[] input = null;
int[,] dp = new int[n, n];
int[,] visited = new int[n, n];
int min = 0;
int currentContinentNumber = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        dp[i, j] = input[j];
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

DistinguishContinent();
visited = new int[n, n];
MinLengthBridge();

Console.WriteLine(min);

void DistinguishContinent()
{
    int number = -1;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (dp[i, j] == 0)
            {
                continue;
            }

            if (dp[i, j] == 1)
            {
                BFS(i, j, number);
                number--;
            }
        }
    }
}

void BFS(int y, int x, int number)
{
    Queue<int[]> q = new Queue<int[]>();
    int ny = 0;
    int nx = 0;
    int[] temp = null;
    q.Enqueue(new int[2] { y, x });
    visited[y, x] = 1;
    dp[y, x] = number;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= n)
            {
                continue;
            }

            if (dp[ny, nx] == 0)
            {
                continue;
            }


            if (dp[ny, nx] == 1)
            {
                dp[ny, nx] = number;
                q.Enqueue(new int[2] { ny, nx });
            }
        }
    }
}

void _BFS(int y, int x)
{
    Queue<int[]> q = new Queue<int[]>();
    q.Enqueue(new int[2] { y, x });
    visited[y, x] = 1;
    int ny = 0;
    int nx = 0;
    int[] temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= n)
            {
                continue;
            }

            if (dp[ny, nx] == currentContinentNumber && visited[ny, nx] == 1)
            {
                continue;
            }

            if (dp[temp[0], temp[1]] == currentContinentNumber && dp[ny, nx] == currentContinentNumber)
            {
                q.Enqueue(new int[2] { ny, nx });
                visited[ny, nx] = 1;
            }
            else if (dp[temp[0], temp[1]] == currentContinentNumber && dp[ny, nx] >= 0)
            {
                dp[ny, nx] = 1;
                visited[ny, nx] = 1;
                q.Enqueue(new int[2] { ny, nx });
            }
            else if (dp[temp[0], temp[1]] > 0 && dp[ny, nx] >= 0)
            {
                if (dp[ny, nx] > dp[temp[0], temp[1]] + 1 || dp[ny, nx] == 0)
                {
                    dp[ny, nx] = dp[temp[0], temp[1]] + 1;
                    visited[ny, nx] = 1;
                    q.Enqueue(new int[2] { ny, nx });
                }
            }
            else if (dp[temp[0], temp[1]] > 0 && dp[ny, nx] == currentContinentNumber)
            {
                continue;
            }
            else if (dp[temp[0], temp[1]] > 0 && dp[ny, nx] < 0 && dp[ny, nx] != currentContinentNumber)
            {
                if (min == 0)
                {
                    min = dp[temp[0], temp[1]];
                }
                else
                {
                    min = Math.Min(min, dp[temp[0], temp[1]]);
                }

                continue;
            }
        }
    }
}

void MinLengthBridge()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (dp[i, j] >= 0)
            {
                continue;
            }

            if (visited[i, j] == 1)
            {
                continue;
            }

            currentContinentNumber = dp[i, j];
            _BFS(i, j);
        }
    }
}