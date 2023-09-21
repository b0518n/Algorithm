int n = int.Parse(Console.ReadLine());
int[,] heights = new int[n, n];
int[] input = null;
int max = -1;

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        heights[i, j] = input[j];
    }
}

int[,] sunkenArea = null;

for (int k = 0; k < 101; k++)
{
    sunkenArea = new int[n, n];
    CheckSunkenArea(heights, sunkenArea, k, n);
    GetSafeArea(sunkenArea, n, ref max);
}

Console.WriteLine(max);

void CheckSunkenArea(int[,] heights, int[,] sunkenArea, int k, int length)
{
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (heights[i, j] <= k)
            {
                sunkenArea[i, j] = 1; // 1 : 잠긴 영역
            }
            else
            {
                sunkenArea[i, j] = 0; // 0 : 안전한 영역
            }
        }
    }
}

void GetSafeArea(int[,] sunkenArea, int length, ref int max)
{
    int[,] visited = new int[length, length];
    int count = 0;

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (sunkenArea[i, j] == 1 || visited[i, j] == 1)
            {
                continue;
            }

            if (visited[i, j] == 0)
            {
                DFS(sunkenArea, visited, i, j, length, ref max);
                count++;
            }
        }
    }

    max = Math.Max(count, max);
}

void DFS(int[,] sunkenArea, int[,] visited, int y, int x, int length, ref int max)
{
    Stack<int[]> stack = new Stack<int[]>();
    visited[y, x] = 1;
    stack.Push(new int[2] { y, x });
    int[] temp = null;

    int ny = 0;
    int nx = 0;

    while (stack.Count > 0)
    {
        temp = stack.Pop();

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= length || nx >= length)
            {
                continue;
            }

            if (sunkenArea[ny, nx] == 1)
            {
                continue;
            }

            if (visited[ny, nx] == 0)
            {
                stack.Push(new int[2] { ny, nx });
                visited[ny, nx] = 1;
            }
        }
    }
}