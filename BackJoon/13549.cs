StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int[] times = new int[100001];
int[] visited = new int[100001];
int[] dx = new int[3] { -1, 1, 2 };

BFS(times, dx, n);
sw.WriteLine(times[k]);
sw.Flush();
sw.Close();

void BFS(int[] times, int[] dx, int start)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited[start] = 1;

    int tmp = 0;
    int nx = 0;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();

        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                nx = tmp * dx[i];
            }
            else
            {
                nx = tmp + dx[i];
            }

            if (nx >= 0 && nx <= 100000)
            {
                if (visited[nx] == 0)
                {
                    if (i == 2)
                    {
                        visited[nx] = 1;
                        times[nx] = times[tmp];
                        queue.Enqueue(nx);
                    }
                    else
                    {
                        visited[nx] = 1;
                        times[nx] = times[tmp] + 1;
                        queue.Enqueue(nx);
                    }
                }
                else
                {
                    if (i == 2)
                    {
                        if (times[nx] > times[tmp])
                        {
                            if (nx == start)
                            {
                                continue;
                            }

                            times[nx] = times[tmp];
                            queue.Enqueue(nx);
                        }
                    }
                    else
                    {
                        if (times[nx] > times[tmp] + 1)
                        {
                            if (nx == start)
                            {
                                continue;
                            }

                            times[nx] = times[tmp] + 1;
                            queue.Enqueue(nx);
                        }
                    }
                }
            }
        }
    }
}