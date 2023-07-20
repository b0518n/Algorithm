StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int m = input[0];
int n = input[1];
int h = input[2];

int[,,] box = new int[h, n, m];
List<int[]> ripeTomatoes = new List<int[]>();


for (int i = 0; i < h; i++)
{
    for (int j = 0; j < n; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int k = 0; k < m; k++)
        {
            box[i, j, k] = input[k];
            if (input[k] == 1)
            {
                ripeTomatoes.Add(new int[3] { i, j, k });
            }
        }
    }

}

int[] dz = new int[6] { 0, 0, 0, 0, 1, -1 };
int[] dy = new int[6] { -1, 1, 0, 0, 0, 0 };
int[] dx = new int[6] { 0, 0, -1, 1, 0, 0 };


BFS(box, ripeTomatoes);

bool flag = false;
int max = -1;

for (int i = 0; i < h; i++)
{
    if (flag)
    {
        break;
    }

    for (int j = 0; j < n; j++)
    {
        if (flag)
        {
            break;
        }

        for (int k = 0; k < m; k++)
        {
            if (box[i, j, k] == 0)
            {
                sw.WriteLine(-1);
                flag = true;
                break;
            }
            else
            {
                if (max < box[i, j, k])
                {
                    max = box[i, j, k];
                }
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

void BFS(int[,,] box, List<int[]> ripeTomatoes)
{
    Queue<int[]> queue = new Queue<int[]>();
    for (int i = 0; i < ripeTomatoes.Count; i++)
    {
        queue.Enqueue(new int[3] { ripeTomatoes[i][0], ripeTomatoes[i][1], ripeTomatoes[i][2] });
    }

    int[] tmp = null;
    int nz = 0;
    int ny = 0;
    int nx = 0;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();
        for (int i = 0; i < 6; i++)
        {
            nz = tmp[0] + dz[i];
            ny = tmp[1] + dy[i];
            nx = tmp[2] + dx[i];

            if (ny >= 0 && ny < n && nx >= 0 && nx < m && nz >= 0 && nz < h)
            {
                if (box[nz, ny, nx] == -1) // 박스가 비어있을 경우
                {
                    continue;
                }

                if (box[nz, ny, nx] == 0) // 토마토가 아직 익지 않은 경우
                {
                    box[nz, ny, nx] = box[tmp[0], tmp[1], tmp[2]] + 1;
                    queue.Enqueue(new int[3] { nz, ny, nx });
                }
                else // 토마토가 익은 경우
                {
                    if (box[nz, ny, nx] > box[tmp[0], tmp[1], tmp[2]] + 1)
                    {
                        box[nz, ny, nx] = box[tmp[0], tmp[1], tmp[2]] + 1;
                        queue.Enqueue(new int[3] { nz, ny, nx });
                    }
                }
            }
        }
    }
}