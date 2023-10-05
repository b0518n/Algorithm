int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int m = input[0];
int n = input[1];
int k = input[2];

int[,] dp = new int[m, n];

int x1 = 0;
int y1 = 0;
int x2 = 0;
int y2 = 0;

for (int i = 0; i < k; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    x1 = input[0];
    y1 = input[1];
    x2 = input[2];
    y2 = input[3];

    for (int j = y1; j < y2; j++)
    {
        for (int l = x1; l < x2; l++)
        {
            dp[j, l] = 1;
        }
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
int count = 0;
List<int> result = new List<int>();

for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (dp[i, j] == 0)
        {
            BFS(i, j);
        }
    }
}

result.Sort();
Console.WriteLine(result.Count);
Console.WriteLine(string.Join(" ", result));

void BFS(int y, int x)
{
    dp[y, x] = -1;
    Queue<int[]> queue = new Queue<int[]>();
    queue.Enqueue(new int[2] { y, x });
    int[] temp = null;
    count++;

    int ny = 0;
    int nx = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= m || nx >= n)
            {
                continue;
            }

            if (dp[ny, nx] != 0)
            {
                continue;
            }

            dp[ny, nx] = -1;
            queue.Enqueue(new int[2] { ny, nx });
            count++;
        }
    }

    result.Add(count);
    count = 0;
}