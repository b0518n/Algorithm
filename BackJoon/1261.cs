StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int m = input[0];
int n = input[1];

int[,] arr = new int[n, m];
int[,] cntArr = new int[n, m];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (i == 0 && j == 0)
            continue;
        else
            cntArr[i, j] = int.MaxValue;
    }
}

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { -1, 1, 0, 0 };

string str = string.Empty;
for (int i = 0; i < n; i++)
{
    str = sr.ReadLine();
    for (int j = 0; j < m; j++)
    {
        arr[i, j] = int.Parse(str[j].ToString());
    }
}

DFS();
sw.WriteLine(cntArr[n - 1, m - 1]);
sw.Flush();
sw.Close();

void DFS()
{
    Stack<PosInfo> stack = new Stack<PosInfo>();
    stack.Push(new PosInfo(0, 0, 0));

    PosInfo temp = null;
    int ny = 0;
    int nx = 0;

    while (stack.Count > 0)
    {
        temp = stack.Pop();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= m)
                continue;

            if (cntArr[ny, nx] == int.MaxValue)
            {
                stack.Push(new PosInfo(ny, nx, temp.cnt + arr[ny, nx]));
                cntArr[ny, nx] = temp.cnt + arr[ny, nx];
            }
            else if (cntArr[ny, nx] > temp.cnt + arr[ny, nx])
            {
                stack.Push(new PosInfo(ny, nx, temp.cnt + arr[ny, nx]));
                cntArr[ny, nx] = temp.cnt + arr[ny, nx];
            }
        }
    }
}

class PosInfo
{
    public int y;
    public int x;
    public int cnt;

    public PosInfo(int _y, int _x, int _cnt)
    {
        this.y = _y;
        this.x = _x;
        this.cnt = _cnt;
    }
}