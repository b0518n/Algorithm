// DFS

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int m = input[0];
int n = input[1];

int[,] heights = new int[m + 1, n + 1];
int[,] routes = new int[m + 1, n + 1];

int[] dy = new int[4] { 0, 0, 1, -1 };
int[] dx = new int[4] { 1, -1, 0, 0 };

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < input.Length; j++)
    {
        heights[i + 1, j + 1] = input[j];
    }
}

for (int i = 1; i <= m; i++)
{
    for (int j = 1; j <= n; j++)
    {
        routes[i, j] = -1;
    }
}

int result = DFS(1, 1);
sw.WriteLine(result);
sw.Flush();
sw.Close();

int DFS(int row, int column)
{
    if (row == m && column == n)
    {
        return 1;
    }

    if (routes[row, column] != -1)
    {
        // 이부분 없이 모든 경우를 완전탐색을 할경우 시간초과 발생
        // -1 이 아니라는 말은 다른 경우에 이 경로를 통해 목표지점까지 도달 했다는 의미이기 때문에,
        // 지금의 경우에도 해당 경우와 동일한 횟수를 도달할 수 있는 것을 의미하기 때문에 탐색을 하지 않고,
        // 해당 값을 탐색없이 바로 return 해줌으로써 시간을 줄일 수 있음.
        return routes[row, column]; 
    }

    routes[row, column] = 0;

    for (int i = 0; i < 4; i++)
    {
        int y = row + dy[i];
        int x = column + dx[i];

        if (y >= 1 && x >= 1 && y <= m && x <= n)
        {
            if (heights[row, column] > heights[y, x])
            {
                routes[row, column] += DFS(y, x);
            }
        }
    }

    return routes[row, column];
}