int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int r = input[0];
int c = input[1];

string str = string.Empty;
int[,] dp = new int[r, c];
for (int i = 0; i < r; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < c; j++)
    {
        if (str[j] == '.')
        {
            dp[i, j] = 0;
        }
        else if (str[j] == 'x')
        {
            dp[i, j] = -1;
        }
    }
}

bool doArrive = false;
int[] dy = new int[3] { -1, 0, 1 };
int[] dx = new int[3] { 1, 1, 1 };
int result = 0;

for (int i = 0; i < r; i++)
{
    DFS(i, 0);
}

Console.WriteLine(result);

void DFS(int y, int x)
{
    if (x == c - 1)
    {
        doArrive = true;
        result++;
    }

    int ny = 0;
    int nx = 0;

    for (int i = 0; i < 3; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || nx < 0 || ny >= r || nx >= c)
        {
            continue;
        }

        if (dp[ny, nx] == 1 || dp[ny, nx] == -1 || dp[ny, nx] == 2) // -1 : 건물, 1 : 파이프라인이 설치된 장소, 2 : 이미 방문을 했는데 빵집까지 도달하지 못한 곳
        {
            continue;
        }

        dp[ny, nx] = 2;
        DFS(ny, nx);
        if (doArrive)
        {
            dp[ny, nx] = 1;
            if (x == 0)
            {
                doArrive = false;
                dp[y, x] = 1;
            }

            break;
        }

    }
}