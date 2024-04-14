StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = -1;
int[] arr = null;
int[] dp = null;
int result = 0;

Input();
Solve();
Print();

void Input()
{
    n = int.Parse(sr.ReadLine());
    arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    dp = new int[n];
}
void Solve()
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(0);
    int temp = 0;
    int nx = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();
        for (int i = 1; i <= arr[temp]; i++)
        {
            nx = temp + i;
            if (nx > n - 1 || (dp[nx] != 0 && dp[nx] <= dp[temp] + 1))
            {
                continue;
            }

            dp[nx] = dp[temp] + 1;
            q.Enqueue(nx);
        }
    }

    result = dp[n - 1];
}
void Print()
{
    if (n == 1)
    {
        sw.WriteLine(0);
    }
    else if (result == 0)
    {
        sw.WriteLine(-1);
    }
    else
    {
        sw.WriteLine(result);
    }

    sw.Flush();
    sw.Close();
}