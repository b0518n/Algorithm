int n = int.Parse(Console.ReadLine());
string[] dp = null;
int[] input = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    dp = new string[10001];
    BFS(input[0], dp, input[1]);
    Console.WriteLine(dp[input[1]]);
}

void BFS(int value, string[] dp, int endValue)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(value);
    dp[value] = string.Empty;
    int dx = 0;
    int nx = 0;

    while (q.Count > 0)
    {
        dx = q.Dequeue();
        if (dx == endValue)
        {
            break;
        }

        nx = DRegister(dx);
        if (dp[nx] == null && nx != value)
        {
            dp[nx] = dp[dx] + "D";
            q.Enqueue(nx);
        }

        nx = SRegister(dx);
        if (dp[nx] == null && nx != value)
        {
            dp[nx] = dp[dx] + "S";
            q.Enqueue(nx);
        }

        nx = LRegister(dx);
        if (dp[nx] == null && nx != value)
        {
            dp[nx] = dp[dx] + "L";
            q.Enqueue(nx);
        }

        nx = RRegister(dx);
        if (dp[nx] == null && nx != value)
        {
            dp[nx] = dp[dx] + "R";
            q.Enqueue(nx);
        }
    }
}

int DRegister(int value)
{
    int _value = value * 2;
    if (_value > 9999)
    {
        _value -= 10000;
    }

    return _value;
}

int SRegister(int value)
{
    if (value == 0)
    {
        return 9999;
    }

    return value - 1;
}

int LRegister(int value)
{
    return (value % 1000) * 10 + (value / 1000);
}

int RRegister(int value)
{
    return (value % 10) * 1000 + (value / 10);
}