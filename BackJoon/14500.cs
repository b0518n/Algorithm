int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] dp = new int[n, m];
int max = -1;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        dp[i, j] = input[j];
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        CheckCase1(i, j);
        CheckCase2(i, j);
        CheckCase3(i, j);
        CheckCase4(i, j);
        CheckCase5(i, j);
        CheckCase6(i, j);
        CheckCase7(i, j);
        CheckCase8(i, j);
        CheckCase9(i, j);
        CheckCase10(i, j);
        CheckCase11(i, j);
        CheckCase12(i, j);
        CheckCase13(i, j);
        CheckCase14(i, j);
        CheckCase15(i, j);
        CheckCase16(i, j);
        CheckCase17(i, j);
        CheckCase18(i, j);
        CheckCase19(i, j);
    }
}

Console.WriteLine(max);

// 1자
void CheckCase1(int y, int x)
{
    int[] dx = new int[4] { 0, 1, 2, 3 };
    int value = 0;

    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        nx = x + dx[i];
        if (nx < 0 || nx >= m)
        {
            break;
        }

        value += dp[y, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase2(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 2, 3 };
    int value = 0;

    int ny = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        if (ny < 0 || ny >= n)
        {
            break;
        }

        value += dp[ny, x];
        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

// ㅁ자
void CheckCase3(int y, int x)
{
    int[] dy = new int[4] { 0, 0, 1, 1 };
    int[] dx = new int[4] { 0, 1, 0, 1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }

        value = value + dp[ny, nx];
        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

// ㄴ자
void CheckCase4(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 2, 2 };
    int[] dx = new int[4] { 0, 0, 0, 1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase5(int y, int x)
{
    int[] dy = new int[4] { 0, 0, 0, 1 };
    int[] dx = new int[4] { 0, 1, 2, 0 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase6(int y, int x)
{
    int[] dy = new int[4] { 0, 0, 1, 2 };
    int[] dx = new int[4] { 0, 1, 1, 1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase7(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 1, 1 };
    int[] dx = new int[4] { 0, 0, -1, -2 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase8(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 2, 0 };
    int[] dx = new int[4] { 0, 0, 0, 1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase9(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 1, 1 };
    int[] dx = new int[4] { 0, 0, 1, 2 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase10(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 2, 2 };
    int[] dx = new int[4] { 0, 0, 0, -1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase11(int y, int x)
{
    int[] dy = new int[4] { 0, 0, 0, 1 };
    int[] dx = new int[4] { 0, 1, 2, 2 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

// ㄹ자
void CheckCase12(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 1, 2 };
    int[] dx = new int[4] { 0, 0, 1, 1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase13(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 0, 1 };
    int[] dx = new int[4] { 0, 0, 1, -1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase14(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 1, 2 };
    int[] dx = new int[4] { 0, 0, -1, -1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase15(int y, int x)
{
    int[] dy = new int[4] { 0, 0, 1, 1 };
    int[] dx = new int[4] { 0, 1, 1, 2 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

// ㅗ자
void CheckCase16(int y, int x)
{
    int[] dy = new int[4] { 0, 0, 1, 0 };
    int[] dx = new int[4] { 0, 1, 1, 2 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase17(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 2, 1 };
    int[] dx = new int[4] { 0, 0, 0, -1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase18(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 1, 1 };
    int[] dx = new int[4] { 0, 0, -1, 1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}

void CheckCase19(int y, int x)
{
    int[] dy = new int[4] { 0, 1, 2, 1 };
    int[] dx = new int[4] { 0, 0, 0, 1 };
    int value = 0;

    int ny = 0;
    int nx = 0;
    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || ny >= n || nx < 0 || nx >= m)
        {
            break;
        }
        value += dp[ny, nx];

        if (i == 3)
        {
            max = Math.Max(max, value);
        }
    }
}