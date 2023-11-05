int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int row = input[0];
int column = input[1];

int[,] dp = new int[row, column];
int count = 0;

for (int i = 0; i < row; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < column; j++)
    {
        dp[i, j] = input[j];
        if (dp[i, j] == 1)
        {
            count++;
        }
    }
}

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { -1, 1, 0, 0 };

Queue<int[]> q = new Queue<int[]>();

int[] tmp = null;
int _y = 0;
int _x = 0;

int time = 0;
int previousCount = 0;

while (true)
{
    if (count == 0)
    {
        break;
    }
    else
    {
        previousCount = count;
    }

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            if (dp[i, j] == 0)
            {
                continue;
            }

            BFS(i, j);
        }
    }

    while (q.Count > 0)
    {
        tmp = q.Dequeue();
        _y = tmp[0];
        _x = tmp[1];

        dp[_y, _x] = 0;
        count--;
    }

    time++;
}

Console.WriteLine(time);
Console.WriteLine(previousCount);


void BFS(int y, int x)
{
    Queue<int[]> queue = new Queue<int[]>();
    queue.Enqueue(new int[2] { y, x });
    Dictionary<string, int> dics = new Dictionary<string, int>();
    dics.Add($"{y} {x}", 1);

    int ny = 0;
    int nx = 0;
    int[] temp = null;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= row || nx >= column)
            {
                continue;
            }

            if (ny == 0 || nx == 0)
            {
                q.Enqueue(new int[2] { y, x });
                return;
            }

            if (dics.ContainsKey($"{ny} {nx}"))
            {
                continue;
            }

            if (dp[ny, nx] == 1)
            {
                continue;
            }

            queue.Enqueue(new int[2] { ny, nx });
            dics.Add($"{ny} {nx}", 1);
        }
    }
}
