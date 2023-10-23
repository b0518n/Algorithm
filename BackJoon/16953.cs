int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];

Dictionary<int, int> dp = new Dictionary<int, int>();
BFS(a);

if (dp.ContainsKey(b))
{
    Console.WriteLine(dp[b]);
}
else
{
    Console.WriteLine(-1);
}

void BFS(int value)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(value);
    dp.Add(value, 1);

    long temp = 0;
    long _value = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                _value = temp * 2;
            }
            else
            {
                _value = (temp * 10) + 1;
            }

            if (_value <= 0 || _value > b)
            {
                continue;
            }

            if (dp.ContainsKey((int)_value) && dp[(int)_value] <= dp[(int)temp] + 1)
            {
                continue;
            }
            else if (!dp.ContainsKey((int)_value))
            {
                dp.Add((int)_value, dp[(int)temp] + 1);
            }
            else
            {
                dp[(int)_value] = dp[(int)temp] + 1;
            }
            queue.Enqueue((int)_value);
        }
    }
}
