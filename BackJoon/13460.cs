int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

string str = null;
string[,] board = new string[n, m];
int[,,,] visited = new int[n, m, n, m];
int min = -1;

int[] marblePosition = new int[4]; // 0, 1 : Red marble x, y , 2, 3 : Blue marble x, y
for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        board[i, j] = str[j].ToString();
        if (board[i, j] == "B")
        {
            marblePosition[2] = j;
            marblePosition[3] = i;
        }
        else if (board[i, j] == "R")
        {
            marblePosition[0] = j;
            marblePosition[1] = i;
        }
    }
}

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { 1, -1, 0, 0 };

BFS(marblePosition[1], marblePosition[0], marblePosition[3], marblePosition[2]);
Console.WriteLine(min);

void BFS(int redY, int redX, int blueY, int blueX)
{
    Queue<int[]> q = new Queue<int[]>();
    q.Enqueue(new int[5] { redY, redX, blueY, blueX, 0 });
    visited[redY, redX, blueY, blueX] = 1;
    int ry = 0, rx = 0, by = 0, bx = 0, cnt = 0;
    int[] temp = null;
    int rDistance = 0, bDistance = 0;

    while (q.Count > 0)
    {
        if (cnt > 10) break;

        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ry = temp[0];
            rx = temp[1];
            by = temp[2];
            bx = temp[3];
            cnt = temp[4] + 1;

            MarbleInfo redMarbleInfo = MoveMarble(ry, rx, i);
            MarbleInfo blueMarbleInfo = MoveMarble(by, bx, i);

            ry = redMarbleInfo.y;
            rx = redMarbleInfo.x;
            rDistance = redMarbleInfo.distance;

            by = blueMarbleInfo.y;
            bx = blueMarbleInfo.x;
            bDistance = blueMarbleInfo.distance;

            if (board[by, bx] == "O") continue;

            if (board[ry, rx] == "O")
            {
                min = cnt;
                return;
            }

            if (ry == by && rx == bx && rDistance > bDistance)
            {
                ry -= dy[i];
                rx -= dx[i];
            }
            else if (ry == by && rx == bx && rDistance < bDistance)
            {
                by -= dy[i];
                bx -= dx[i];
            }

            if (visited[ry, rx, by, bx] == 1) continue;
            visited[ry, rx, by, bx] = 1;
            q.Enqueue(new int[5] { ry, rx, by, bx, cnt });
        }
    }
}

MarbleInfo MoveMarble(int y, int x, int dir)
{
    int distance = 0;
    while (board[y + dy[dir], x + dx[dir]] != "#" && board[y, x] != "O")
    {
        y += dy[dir];
        x += dx[dir];
        distance++;
    }

    return new MarbleInfo(y, x, distance);
}

class MarbleInfo
{
    public int y;
    public int x;
    public int distance;

    public MarbleInfo(int y, int x, int distance)
    {
        this.y = y;
        this.x = x;
        this.distance = distance;
    }
}