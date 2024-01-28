int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int r = input[0];
int c = input[1];

string[,] board = new string[r, c];
int[,] visited = new int[r, c];
Dictionary<string, int> dics = new Dictionary<string, int>();

string str = null;
int result = -1;

for (int i = 0; i < r; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < c; j++)
    {
        board[i, j] = str[j].ToString();
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };

visited[0, 0] = 1;
dics.Add(board[0, 0], 1);
DFS(0, 0, 1);

Console.WriteLine(result);

void DFS(int y, int x, int cnt)
{
    int ny = 0;
    int nx = 0;

    result = Math.Max(result, cnt);

    for (int i = 0; i < 4; i++)
    {
        ny = y + dy[i];
        nx = x + dx[i];

        if (ny < 0 || nx < 0 || ny >= r || nx >= c || visited[ny, nx] == 1 || dics.ContainsKey(board[ny, nx]))
        {
            continue;
        }

        visited[ny, nx] = 1;
        dics.Add(board[ny, nx], 1);
        DFS(ny, nx, cnt + 1);
        dics.Remove(board[ny, nx]);
        visited[ny, nx] = 0;
    }
}