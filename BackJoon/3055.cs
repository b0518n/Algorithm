int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int r = input[0];
int c = input[1];
string[,] field = new string[r, c];
string str = string.Empty;
objectInfo destination = null; // 동굴 위치
objectInfo hedgehog = null; // 고슴도치 위치
Dictionary<string, int> rock = new Dictionary<string, int>();
Dictionary<string, int> floodedArea = new Dictionary<string, int>();
int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
int result = -1;

for (int i = 0; i < r; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < c; j++)
    {
        field[i, j] = str[j].ToString();
        if (field[i, j] == "*")
        {
            floodedArea.Add($"{i} {j}", 1);
        }
        else if (field[i, j] == "X")
        {
            rock.Add($"{i} {j}", 1);
        }
        else if (field[i, j] == "D")
        {
            destination = new objectInfo(i, j);
        }
        else if (field[i, j] == "S")
        {
            hedgehog = new objectInfo(i, j);
        }
    }
}

string[] tmp = null;

foreach (string temp in floodedArea.Keys)
{
    tmp = temp.Split(" ");
    BroadenFloodedArea(int.Parse(tmp[0]), int.Parse(tmp[1]));
}

MoveHedgeHog(hedgehog.y, hedgehog.x);

if (result == -1)
{
    Console.WriteLine("KAKTUS");
}
else
{
    Console.WriteLine(result);
}

void MoveHedgeHog(int y, int x)
{
    Queue<string> q = new Queue<string>();
    q.Enqueue($"{y} {x} {1}");
    string temp = string.Empty;
    int ny = 0;
    int nx = 0;
    int[,] visited = new int[r, c];
    visited[y, x] = 1;
    int time = 0;
    string[] tmp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        tmp = temp.Split(" ");

        for (int i = 0; i < 4; i++)
        {
            ny = int.Parse(tmp[0]) + dy[i];
            nx = int.Parse(tmp[1]) + dx[i];
            time = int.Parse(tmp[2]);

            if (ny < 0 || nx < 0 || ny >= r || nx >= c) // 배열의 범위를 벗어난 경우
            {
                continue;
            }

            if (rock.ContainsKey($"{ny} {nx}")) // 돌
            {
                continue;
            }

            if (field[ny, nx] == "*") // 물로 잠긴 지역
            {
                continue;
            }

            if (field[ny, nx] == "D") // 동굴
            {
                result = time;
                return;
            }

            if (field[ny, nx] == "S")
            {
                continue;
            }

            if (visited[ny, nx] == 1) // 방문한 곳
            {
                continue;
            }

            if (field[ny, nx] == ".")
            {
                q.Enqueue($"{ny} {nx} {time + 1}");
                visited[ny, nx] = 1;
                continue;
            }

            if (int.Parse(field[ny, nx]) <= time) // 물로 잠긴 지역
            {
                continue;
            }

            q.Enqueue($"{ny} {nx} {time + 1}");
            visited[ny, nx] = 1;
        }

    }
}

void BroadenFloodedArea(int y, int x)
{
    Queue<string> q = new Queue<string>();
    q.Enqueue($"{y} {x}");
    string temp = string.Empty;
    int ny = 0;
    int nx = 0;
    string[] tmp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        tmp = temp.Split(" ");

        for (int i = 0; i < 4; i++)
        {
            ny = int.Parse(tmp[0]) + dy[i];
            nx = int.Parse(tmp[1]) + dx[i];

            if (ny < 0 || nx < 0 || ny >= r || nx >= c) // 배열의 범위의 범위를 벗어난 경우
            {
                continue;
            }

            if (rock.ContainsKey($"{ny} {nx}")) // 돌
            {
                continue;
            }

            if (destination.y == ny && destination.x == nx) // 동굴
            {
                continue;
            }

            if (field[ny, nx] == "." || field[ny, nx] == "S") // 물에 잠기지 않은 지역
            {
                q.Enqueue($"{ny} {nx}");
                if (field[int.Parse(tmp[0]), int.Parse(tmp[1])] == "*")
                {
                    field[ny, nx] = 1.ToString();
                }
                else
                {
                    field[ny, nx] = (int.Parse(field[int.Parse(tmp[0]), int.Parse(tmp[1])]) + 1).ToString();
                }
                continue;
            }

            if (field[ny, nx] == "*") // 방문했던 곳에 재 방문 방지
            {
                continue;
            }

            if (field[int.Parse(tmp[0]), int.Parse(tmp[1])] == "*")
            {
                field[ny, nx] = 1.ToString();
                continue;
            }


            if (int.Parse(field[ny, nx]) > int.Parse(
                (int.Parse(field[int.Parse(tmp[0]), int.Parse(tmp[1])]) + 1).ToString()))
            {
                q.Enqueue($"{ny} {nx}");
                field[ny, nx] = (int.Parse(field[int.Parse(tmp[0]), int.Parse(tmp[1])]) + 1).ToString();
                continue;
            }

        }
    }
}

class objectInfo
{
    public int y;
    public int x;

    public objectInfo(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}