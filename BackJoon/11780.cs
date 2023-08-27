int n = int.Parse(Console.ReadLine()); // 도시의 개수
int m = int.Parse(Console.ReadLine()); // 버스의 개수

int[] input = null;
int a = 0; // 시작 도시
int b = 0; // 도착 도시
int c = 0; // 비용

int[,] dp = new int[n + 1, n + 1];
int[,] _dp = new int[n + 1, n + 1];

for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        dp[i, j] = int.MaxValue;
        _dp[i, j] = int.MaxValue;
    }
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    if (dp[a, b] == int.MaxValue)
    {
        dp[a, b] = c;
        _dp[a, b] = b;
    }
    else
    {
        if (dp[a, b] > c)
        {
            dp[a, b] = c;
            _dp[a, b] = b;
        }
    }
}

Floyd_Warshall(dp, n, _dp);
Print(dp, n, _dp);

void Floyd_Warshall(int[,] dp, int n, int[,] _dp)
{
    for (int i = 1; i < n + 1; i++) // 중간경로
    {
        for (int j = 1; j < n + 1; j++) // 시작점
        {
            if (i == j)
            {
                continue;
            }

            if (dp[j, i] == int.MaxValue)
            {
                continue;
            }

            for (int k = 1; k < n + 1; k++)
            {
                if (dp[i, k] == int.MaxValue)
                {
                    continue;
                }

                if (j == k)
                {
                    continue;
                }

                if (dp[j, k] == int.MaxValue)
                {
                    dp[j, k] = dp[j, i] + dp[i, k];
                    _dp[j, k] = i;
                }
                else
                {
                    if (dp[j, k] > dp[j, i] + dp[i, k])
                    {
                        dp[j, k] = dp[j, i] + dp[i, k];
                        _dp[j, k] = i;
                    }
                }
            }
        }
    }
}

void Print(int[,] dp, int n, int[,] _dp)
{
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (dp[i, j] == int.MaxValue)
            {
                if (j == 1)
                {
                    Console.Write(0);
                }
                else
                {
                    Console.Write(" " + 0);
                }

            }
            else
            {
                if (j == 1)
                {
                    Console.Write(dp[i, j]);
                }
                else
                {
                    Console.Write(" " + dp[i, j]);
                }
            }
        }

        Console.WriteLine();
    }

    Queue<int> q = new Queue<int>();

    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (_dp[i, j] == int.MaxValue)
            {
                Console.WriteLine(0);
            }
            else
            {
                q.Clear();
                int start = i;
                int end = j;
                int mid = end;

                q.Enqueue(start);

                while (true)
                {
                    if (mid == end && _dp[start, mid] == end)
                    {
                        q.Enqueue(end);
                        break;
                    }

                    if (_dp[start, mid] != mid)
                    {
                        mid = _dp[start, mid];
                    }
                    else
                    {
                        start = mid;
                        mid = end;
                        q.Enqueue(start);
                    }
                }

                Console.Write(q.Count + " ");
                Console.WriteLine(string.Join(" ", q));
            }
        }
    }
}