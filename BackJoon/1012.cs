StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
int[] input = null;

int m = 0; // 가로길이
int n = 0; // 세로길이
int k = 0; // 배추가 심어져 있는 위치 개수

int[,] fields = null;
int[,] visited = null;

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

int count = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    m = input[0];
    n = input[1];
    k = input[2];

    fields = new int[n, m];
    visited = new int[n, m];
    count = 0;

    for (int j = 0; j < k; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        fields[input[1], input[0]] = 1;
    }

    for (int j = 0; j < n; j++)
    {
        for (int l = 0; l < m; l++)
        {
            DFS_Start(fields, visited, j, l);
        }
    }

    sw.WriteLine(count);
}

sw.Flush();
sw.Close();

void DFS_Start(int[,] fields, int[,] visited, int y, int x)
{
    if (y < 0 || x < 0 || y >= n || x >= m)
    {
        return;
    }

    if (visited[y, x] != 0 || fields[y, x] != 1)
    {
        return;
    }

    count++;
    visited[y, x] = 1;

    for (int i = 0; i < 4; i++)
    {
        DFS(fields, visited, y + dy[i], x + dx[i]);
    }
}

void DFS(int[,] fields, int[,] visited, int y, int x)
{
    if (y < 0 || x < 0 || y >= n || x >= m)
    {
        return;
    }

    if (visited[y, x] != 0 || fields[y, x] != 1)
    {
        return;
    }

    visited[y, x] = 1;

    for (int i = 0; i < 4; i++)
    {
        DFS(fields, visited, y + dy[i], x + dx[i]);
    }
}