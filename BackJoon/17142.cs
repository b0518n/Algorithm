int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[,] laboratory = new int[n, n];
List<Virus> virus = new List<Virus>();
int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };
int result = int.MaxValue;
int emptySpace = 0;

// 0 : 활성화된 바이러스의 위치, 1 : 벽, 2 : 빈 공간, 3 : 비활성화된 바이러스 위치
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        if (input[j] == 0)
        {
            laboratory[i, j] = 2; // 빈 공간
            emptySpace++;
        }
        else if (input[j] == 2)
        {
            laboratory[i, j] = 3; // 바이러스 위치
            virus.Add(new Virus(i, j));
        }
        else // 벽
        {
            laboratory[i, j] = input[j];
        }

    }
}

SelectVirus(0, new List<int>());

Console.WriteLine(result);

void SelectVirus(int start, List<int> list)
{
    if (list.Count == m)
    {
        SpreadVirus(list, DeepCopy(laboratory, n), emptySpace);
        return;
    }

    for (int i = start; i < virus.Count; i++)
    {
        list.Add(i);
        SelectVirus(i + 1, list);
        list.RemoveAt(list.Count - 1);
    }
}

void SpreadVirus(List<int> list, int[,] laboratory, int emptySpace)
{
    Queue<Virus> q = new Queue<Virus>();
    foreach (int i in list)
    {
        q.Enqueue(new Virus(virus[i].y, virus[i].x));
        laboratory[virus[i].y, virus[i].x] = 0;
    }

    int ny = 0;
    int nx = 0;
    Virus temp = null;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            ny = temp.y + dy[i];
            nx = temp.x + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= n || laboratory[ny, nx] == 1)
            {
                continue;
            }

            if (laboratory[ny, nx] == 2)
            {
                laboratory[ny, nx] = laboratory[temp.y, temp.x] - 1;
                q.Enqueue(new Virus(ny, nx));
                emptySpace--;
            }

            if (laboratory[ny, nx] == 3)
            {
                if (emptySpace != 0)
                {
                    laboratory[ny, nx] = laboratory[temp.y, temp.x] - 1;
                    q.Enqueue(new Virus(ny, nx));
                }
            }
        }
    }

    int cnt = int.MaxValue;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (laboratory[i, j] == 2)
            {
                if (result == int.MaxValue)
                {
                    result = -1;
                }

                return;
            }
            else
            {
                if (laboratory[i, j] > 0)
                {
                    continue;
                }

                cnt = Math.Min(cnt, laboratory[i, j]);
            }
        }
    }

    if (cnt == int.MaxValue)
    {
        result = 0;
    }
    else
    {
        if (result == -1)
        {
            result = cnt * -1;
        }
        else
        {
            result = Math.Min(result, cnt * -1);
        }
    }
}

int[,] DeepCopy(int[,] arr, int size)
{
    int[,] tempArr = new int[size, size];

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            tempArr[i, j] = arr[i, j];
        }
    }

    return tempArr;
}

class Virus
{
    public int y;
    public int x;

    public Virus(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}