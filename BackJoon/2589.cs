int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int row = input[0];
int column = input[1];

string str = null;
string[,] dp = new string[row, column];

for (int i = 0; i < row; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < column; j++)
    {
        dp[i, j] = str[j].ToString();
    }
}

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { -1, 1, 0, 0 };

int result = 0;
for (int i = 0; i < row; i++)
{
    for (int j = 0; j < column; j++)
    {
        if (dp[i, j] == "W")
        {
            continue;
        }

        BFS(i, j);
    }
}

Console.WriteLine(result);

void BFS(int y, int x)
{
    int[,] visited = new int[row, column];
    int[,] distances = new int[row, column];

    Queue<int[]> q = new Queue<int[]>();
    q.Enqueue(new int[2] { y, x });
    visited[y, x] = 1;

    int[] temp = null;
    int ny = 0;
    int nx = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= row || nx >= column)
            {
                continue;
            }

            if (visited[ny, nx] == 1)
            {
                continue;
            }

            if (dp[ny, nx] == "W")
            {
                continue;
            }

            q.Enqueue(new int[2] { ny, nx });
            visited[ny, nx] = 1;
            distances[ny, nx] = distances[temp[0], temp[1]] + 1;
            result = Math.Max(result, distances[ny, nx]);
        }
    }

}
