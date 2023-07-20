StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int m = input[0];
int n = input[1];

int[,] box = new int[n, m];
List<int[]> ripeTomatoes = new List<int[]>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        box[i, j] = input[j];
        if (input[j] == 1)
        {
            ripeTomatoes.Add(new int[2] { i, j });
        }
    }
}

int[] dy = new int[4] { -1, 1, 0, 0 };
int[] dx = new int[4] { 0, 0, -1, 1 };


BFS(box, ripeTomatoes);

bool flag = false;
int max = -1;

for (int i = 0; i < n; i++)
{
    if (flag)
    {
        break;
    }

    for (int j = 0; j < m; j++)
    {
        if (box[i, j] == 0)
        {
            sw.WriteLine(-1);
            flag = true;
            break;
        }
        else
        {
            if (max < box[i, j])
            {
                max = box[i, j];
            }
        }
    }
}

if (!flag)
{
    sw.WriteLine(max - 1);
}

sw.Flush();
sw.Close();

void BFS(int[,] box, List<int[]> ripeTomatoes)
{
    Queue<int[]> queue = new Queue<int[]>();
    for (int i = 0; i < ripeTomatoes.Count; i++)
    {
        queue.Enqueue(new int[2] { ripeTomatoes[i][0], ripeTomatoes[i][1] });
    }

    int[] tmp = null;
    int ny = 0;
    int nx = 0;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            ny = tmp[0] + dy[i];
            nx = tmp[1] + dx[i];

            if (ny >= 0 && ny < n && nx >= 0 && nx < m)
            {
                if (box[ny, nx] == -1) // 박스가 비어있을 경우
                {
                    continue;
                }

                if (box[ny, nx] == 0) // 토마토가 아직 익지 않은 경우
                {
                    box[ny, nx] = box[tmp[0], tmp[1]] + 1;
                    queue.Enqueue(new int[2] { ny, nx });
                }
                else // 토마토가 익은 경우
                {
                    if (box[ny, nx] > box[tmp[0], tmp[1]] + 1)
                    {
                        box[ny, nx] = box[tmp[0], tmp[1]] + 1;
                        queue.Enqueue(new int[2] { ny, nx });
                    }
                }
            }
        }
    }
}