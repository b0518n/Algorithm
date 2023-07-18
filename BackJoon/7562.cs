StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());

int[] input = null;
int l = 0; // 체스판 한 변의 길이
int startY = 0;
int startX = 0;
int endY = 0;
int endX = 0;

int[,] chess = null;
int[] dy = new int[8] { 2, 2, -2, -2, 1, 1, -1, -1 };
int[] dx = new int[8] { 1, -1, 1, -1, 2, -2, 2, -2 };

for (int i = 0; i < t; i++)
{
    l = int.Parse(Console.ReadLine());
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    startY = input[0];
    startX = input[1];

    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    endY = input[0];
    endX = input[1];

    chess = new int[l, l];
    BFS(chess, startY, startX);
    sw.WriteLine(chess[endY, endX] - 1);
}

sw.Flush();
sw.Close();


void BFS(int[,] chess, int y, int x)
{
    chess[y, x] = 1;
    Queue<int[]> queue = new Queue<int[]>();
    queue.Enqueue(new int[2] { y, x });
    int[] tmp = null;
    int ny = 0;
    int nx = 0;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();
        for (int i = 0; i < 8; i++)
        {
            ny = tmp[0] + dy[i];
            nx = tmp[1] + dx[i];

            if (ny >= 0 && ny < l && nx >= 0 && nx < l)
            {
                if (chess[ny, nx] == 0)
                {
                    chess[ny, nx] = chess[tmp[0], tmp[1]] + 1;
                    queue.Enqueue(new int[2] { ny, nx });
                }
                else
                {
                    if (chess[ny, nx] > chess[tmp[0], tmp[1]] + 1)
                    {
                        chess[ny, nx] = chess[tmp[0], tmp[1]] + 1;
                        queue.Enqueue(new int[2] { ny, nx });
                    }
                }
            }
        }
    }
}