int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

Dictionary<int, int> dp = new Dictionary<int, int>();
dp.Add(n, 0);
int count = 1;

int[] dx = new int[3] { -1, 1, 2 };
BFS(n);
Console.WriteLine(dp[k]);
Console.WriteLine(count);

void BFS(int index)
{
    int nx = 0;
    Queue<int> q = new Queue<int>();
    q.Enqueue(index);
    int temp = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                nx = temp * dx[i];
            }
            else
            {
                nx = temp + dx[i];
            }

            if (nx < 0 || nx > 100000)
            {
                continue;
            }

            if (nx == n)
            {
                continue;
            }

            if (!dp.ContainsKey(nx))
            {
                dp.Add(nx, dp[temp] + 1);
                q.Enqueue(nx);

                if (nx == k)
                {
                    count = 1;
                }
            }
            else
            {
                if (dp[nx] > dp[temp] + 1)
                {
                    dp[nx] = dp[temp] + 1;
                    q.Enqueue(nx);
                    if (nx == k)
                    {
                        count++;
                    }
                }
                else if (dp[nx] == dp[temp] + 1)
                {
                    q.Enqueue(nx);
                    if (nx == k)
                    {
                        count++;
                    }
                }
            }
        }
    }
}