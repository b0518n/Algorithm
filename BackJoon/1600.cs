int k = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int w = input[0];
int h = input[1];
int[] dy = new int[12] { -1, 1, 0, 0, -1, -1, -2, -2, 1, 1, 2, 2 };
int[] dx = new int[12] { 0, 0, -1, 1, -2, 2, -1, 1, -2, 2, -1, 1 };
int[,] field = InputData(h, w);
int result = -1;
BFS(0, 0, k);

Console.WriteLine(result);

int[,] InputData(int row, int column)
{
    int[] input = null;
    int[,] tempArr = new int[row, column];

    for (int i = 0; i < row; i++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int j = 0; j < column; j++)
        {
            if (input[j] == 1)
            {
                tempArr[i, j] = -1;
            }
            else
            {
                tempArr[i, j] = 0;
            }
        }
    }

    return tempArr;
}
void BFS(int y, int x, int k)
{
    Queue<Data> q = new Queue<Data>();
    q.Enqueue(new Data(y, x, 0, 0));
    Dictionary<string, int> visited = new Dictionary<string, int>();
    visited.Add($"{y} {x} {0}", 1);
    int ny = 0;
    int nx = 0;
    int _k = 0;
    int _cnt = 0;
    Data data = null;

    while (q.Count > 0)
    {
        data = q.Dequeue();
        _k = data.k;
        _cnt = data.cnt;

        if ((data.y == h - 1 && data.x == w - 1))
        {
            result = _cnt;
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            ny = data.y + dy[i];
            nx = data.x + dx[i];

            if ((ny == h - 1 && nx == w - 1))
            {
                result = _cnt + 1;
                return;
            }

            if (ny < 0 || nx < 0 || ny >= h || nx >= w || field[ny, nx] == -1 || visited.ContainsKey($"{ny} {nx} {_k}"))
            {
                continue;
            }

            q.Enqueue(new Data(ny, nx, _k, _cnt + 1));
            visited.Add($"{ny} {nx} {_k}", 1);
        }

        if (_k < k)
        {
            for (int i = 4; i < 12; i++)
            {
                ny = data.y + dy[i];
                nx = data.x + dx[i];

                if (ny < 0 || nx < 0 || ny >= h || nx >= w || field[ny, nx] == -1 || visited.ContainsKey($"{ny} {nx} {_k + 1}"))
                {
                    continue;
                }

                q.Enqueue(new Data(ny, nx, _k + 1, _cnt + 1));
                visited.Add($"{ny} {nx} {_k + 1}", 1);
            }
        }
    }
}

class Data
{
    public int y;
    public int x;
    public int k;
    public int cnt;

    public Data(int y, int x, int k, int cnt)
    {
        this.y = y;
        this.x = x;
        this.k = k;
        this.cnt = cnt;
    }
}