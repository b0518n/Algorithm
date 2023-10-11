int n = int.Parse(Console.ReadLine());
string input = null;
char[,] dp = new char[n, n];
char[,] _dp = new char[n, n];

int[,] visited = new int[n, n];
int[,] _visited = new int[n, n];

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { -1, 1, 0, 0 };

int normalCase = 0;
int uniqueCase = 0;

for (int i = 0; i < n; i++)
{
    input = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        dp[i, j] = input[j];
        _dp[i, j] = input[j];
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (visited[i, j] == 0)
        {
            DFS(i, j, dp[i, j]);
        }

        if (_visited[i, j] == 0)
        {
            _DFS(i, j, _dp[i, j]);
        }
    }
}

Console.WriteLine($"{normalCase} {uniqueCase}");

// 적록색약일경우
void DFS(int y, int x, char _char)
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

        for (int i = 0; i < 4; i++)
        {
            ny = temp[0] + dy[i];
            nx = temp[1] + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= n)
            {
                continue;
            }

            if (visited[ny, nx] == 1)
            {
                continue;
            }

            if (_char == 'R' || _char == 'G')
            {
                if (dp[ny, nx] == 'R' || dp[ny, nx] == 'G')
                {
                    visited[ny, nx] = 1;
                    stack.Push(new int[2] { ny, nx });
                }
            }
            else if (_char == 'B' && dp[ny, nx] == 'B')
            {
                visited[ny, nx] = 1;
                stack.Push(new int[2] { ny, nx });
            }
        }
    }

    uniqueCase++;
}

// 정상인의 경우
void _DFS(int y, int x, char _char)
{
    Stack<int[]> stack = new Stack<int[]>();
    stack.Push(new int[2] { y, x });
    _visited[y, x] = 1;

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

            if (ny < 0 || nx < 0 || ny >= n || nx >= n)
            {
                continue;
            }

            if (_visited[ny, nx] == 1)
            {
                continue;
            }

            if (_char == 'R' && dp[ny, nx] == 'R')
            {
                _visited[ny, nx] = 1;
                stack.Push(new int[2] { ny, nx });
            }
            else if (_char == 'G' && dp[ny, nx] == 'G')
            {
                _visited[ny, nx] = 1;
                stack.Push(new int[2] { ny, nx });
            }
            else if (_char == 'B' && dp[ny, nx] == 'B')
            {
                _visited[ny, nx] = 1;
                stack.Push(new int[2] { ny, nx });
            }
        }
    }

    normalCase++;
}