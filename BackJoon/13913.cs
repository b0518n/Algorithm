int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int[] dp = new int[100001];
int[] dx = new int[3] { -1, 1, 2 };
dp[n] = 0;
BFS(n);
Console.WriteLine(dp[k]);
GetSequence(k);

void BFS(int index)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(index);
    int temp = 0;
    int nx = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                nx = temp * dx[i];
                if (nx < 0 || nx > 100000)
                {
                    continue;
                }

                if (nx == n)
                {
                    continue;
                }

                if (dp[nx] == 0)
                {
                    dp[nx] = dp[temp] + 1;
                    q.Enqueue(nx);
                }
                else
                {
                    if (dp[nx] > dp[temp] + 1)
                    {
                        dp[nx] = dp[temp] + 1;
                        q.Enqueue(nx);
                    }
                }
            }
            else
            {
                nx = temp + dx[i];
                if (nx < 0 || nx > 100000)
                {
                    continue;
                }

                if (nx == n)
                {
                    continue;
                }

                if (dp[nx] == 0)
                {
                    dp[nx] = dp[temp] + 1;
                    q.Enqueue(nx);
                }
                else
                {
                    if (dp[nx] > dp[temp] + 1)
                    {
                        dp[nx] = dp[temp] + 1;
                        q.Enqueue(nx);
                    }
                }
            }
        }
    }
}

void GetSequence(int index)
{
    int temp = index;
    int nx = 0;
    Stack<int> stack = new Stack<int>();

    while (true)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 2)
            {
                if (temp % 2 == 0)
                {
                    nx = temp / 2;
                    if (nx < 0 || nx > 100000)
                    {
                        continue;
                    }

                    if (dp[nx] == dp[temp] - 1)
                    {
                        stack.Push(temp);
                        temp = nx;
                        break;
                    }
                }
            }
            else
            {
                nx = temp + dx[i];
                if (nx < 0 || nx > 100000)
                {
                    continue;
                }

                if (dp[nx] == dp[temp] - 1)
                {
                    stack.Push(temp);
                    temp = nx;
                    break;
                }
            }
        }

        if (dp[temp] == 0)
        {
            stack.Push(temp);
            break;
        }
    }

    Console.Write(stack.Pop());

    while (stack.Count > 0)
    {
        Console.Write(" " + stack.Pop());
    }
}