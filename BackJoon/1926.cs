int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] dp = new int[n, m];
int[,] visited = new int[n, m];

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        dp[i, j] = input[j];
    }
}

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { 1, -1, 0, 0 };

int count = 0;
int maxArea = 0;

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (dp[i, j] == 1 && visited[i, j] == 0)
        {
            DFS(i, j);
        }
    }
}

Console.WriteLine(count);
Console.WriteLine(maxArea);

void DFS(int y, int x)
{
    Stack<int[]> stack = new Stack<int[]>();
    stack.Push(new int[2] { y, x });
    visited[y, x] = 1;

    int[] temp = null;
    int ny = 0;
    int nx = 0;
    int area = 1;

    while (stack.Count > 0)
    {
        temp = stack.Pop();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= m)
            {
                continue;
            }

            if (visited[ny, nx] == 1 || dp[ny, nx] == 0)
            {
                continue;
            }

            stack.Push(new int[] { ny, nx });
            visited[ny, nx] = 1;
            area++;
        }
    }

    count++;
    maxArea = Math.Max(maxArea, area);
}