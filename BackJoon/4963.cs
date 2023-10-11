using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = null;
int w = 0;
int h = 0;
int[,] dp = null;
int[,] visited = null;
int result = 0;
int[] dy = new int[8] { 0, 0, -1, -1, -1, 1, 1, 1 };
int[] dx = new int[8] { -1, 1, 0, -1, 1, 0, -1, 1 };

while (true)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    w = input[0];
    h = input[1];

    if (w == 0 && h == 0)
    {
        break;
    }

    dp = new int[h, w];
    visited = new int[h, w];

    for (int i = 0; i < h; i++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int j = 0; j < w; j++)
        {
            dp[i, j] = input[j];
        }
    }

    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            if (visited[i, j] == 1 || dp[i, j] == 0)
            {
                continue;
            }

            DFS(i, j);
        }
    }

    sb.AppendLine(result.ToString());
    result = 0;
}

Console.WriteLine(sb.ToString());

void DFS(int y, int x)
{
    Stack<int[]> stack = new Stack<int[]>();
    stack.Push(new int[2] { y, x });
    visited[y, x] = 1;
    int[] temp = null;
    int ny = 0;
    int nx = 0;

    while (stack.Count > 0)
    {
        temp = stack.Pop();
        for (int i = 0; i < 8; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= h || nx >= w)
            {
                continue;
            }

            if (visited[ny, nx] == 1 || dp[ny, nx] == 0)
            {
                continue;
            }

            stack.Push(new int[2] { ny, nx });
            visited[ny, nx] = 1;
        }
    }

    result++;
}