StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

string str = null;
int[,] matrix = new int[n, m];

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = int.Parse(str[j].ToString());
    }
}

int[,,] visited = new int[2, n, m];
int result = BFS(matrix, visited);
sw.WriteLine(result);
sw.Flush();
sw.Close();


// 처음 2차원 배열로 DFS를 통해 방문하지 않았을 경우 바로 대입, 방문했을 경우 해당위치의 값보다 더 작을 경우 다시 DFS를 반복하는 방식을,
// 사용했지만, 벽을 뚫은 경우 뚫지 않은 경우보다 값이 더 작아 뚫지 않은 경우는 해당위치까지 재귀를 반복하지 못하는 경우가 발생함.

// 벽을 뚫은 경우와 뚫지 않은 경우를 배열의 맨 앞 인덱스 0과 1로 뚫은 경우와 뚫지 않은 경우를 구분함.
int BFS(int[,] matrix, int[,,] visited)
{
    Queue<int[]> q = new Queue<int[]>();
    q.Enqueue(new int[3] { 0, 0, 0 });
    visited[0, 0, 0] = 1;
    int[] temp = null;

    int z = 0; // 벽을 한번 뚫은 경우 1, 뚫지 않은 경우 0
    int y = 0;
    int x = 0;

    int ny = 0;
    int nx = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        z = temp[0];
        y = temp[1];
        x = temp[2];

        if (y == n - 1 && x == m - 1)
        {
            return visited[z, y, x];
        }

        for (int i = 0; i < 4; i++)
        {
            ny = y + dy[i];
            nx = x + dx[i];

            if (ny >= 0 && ny < n && nx >= 0 && nx < m)
            {
                if (matrix[ny, nx] == 0 && visited[z, ny, nx] == 0)
                {
                    visited[z, ny, nx] = visited[z, y, x] + 1;
                    q.Enqueue(new int[3] { z, ny, nx });
                }
                else if (matrix[ny, nx] == 1 && z == 0)
                {
                    visited[z + 1, ny, nx] = visited[z, y, x] + 1;
                    q.Enqueue(new int[3] { z + 1, ny, nx });
                }
            }
        }
    }

    return -1;
}