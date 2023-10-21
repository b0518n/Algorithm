int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] dp = new int[n, m];
int[,] visited = null;
int island = 0;
int time = 0;
Dictionary<string, int> dics = new Dictionary<string, int>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        dp[i, j] = input[j];
        if (input[j] != 0)
        {
            dics.Add($"{i} {j}", input[j]);
        }
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
int[] temp = null;

while (true)
{
    foreach (string str in dics.Keys)
    {
        if (dics[str] == 0)
        {
            continue;
        }

        temp = Array.ConvertAll(str.Split(), int.Parse);

        Solve(temp[0], temp[1]);
    }

    foreach (string str in dics.Keys)
    {
        temp = Array.ConvertAll(str.Split(), int.Parse);

        dp[temp[0], temp[1]] = dics[str];
        if (dics[str] == 0)
        {
            dics.Remove(str);
        }
    }

    visited = new int[n, m];

    foreach (string str in dics.Keys)
    {
        if (dics[str] != 0)
        {
            temp = Array.ConvertAll(str.Split(), int.Parse);

            if (visited[temp[0], temp[1]] == 1)
            {
                continue;
            }

            DFS(temp[0], temp[1]);
        }
    }

    time++;

    if (island > 1)
    {
        break;
    }
    else if (dics.Count == 0)
    {
        break;
    }

    island = 0;
}

if (dics.Count == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(time);
}


void Solve(int y, int x)
{
    int ny = 0;
    int nx = 0;
    int count = 0;

    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || nx < 0 || ny >= n || nx >= m)
        {
            continue;
        }

        if (dp[ny, nx] != 0)
        {
            continue;
        }

        count++;
    }

    if (count >= dics[$"{y} {x}"])
    {
        dics[$"{y} {x}"] = 0;
    }
    else
    {
        dics[$"{y} {x}"] -= count;
    }
}

void DFS(int y, int x)
{
    Stack<int[]> stack = new Stack<int[]>();
    stack.Push(new int[2] { y, x });
    visited[y, x] = 1;
    int ny = 0;
    int nx = 0;
    int[] temp = null;

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

            if (visited[ny, nx] == 1)
            {
                continue;
            }

            if (dp[ny, nx] == 0)
            {
                continue;
            }

            stack.Push(new int[2] { ny, nx });
            visited[ny, nx] = 1;

        }
    }

    island++;
}