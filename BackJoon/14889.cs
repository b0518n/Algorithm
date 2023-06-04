int n = int.Parse(Console.ReadLine());
int[] input = null;
int[,] arr = new int[n, n];
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        arr[i, j] = input[j];
    }
}

Dictionary<int, int> startTim = new Dictionary<int, int>();
Dictionary<int, int> linkTim = new Dictionary<int, int>();
int min = 2001;
Solve(1);
Console.WriteLine(min);

void Solve(int index)
{
    if (startTim.Count == n / 2)
    {
        Calculate();
        return;
    }

    for (int i = index; i <= n; i++)
    {
        if (!startTim.ContainsKey(i))
        {
            startTim.Add(i, 1);
            Solve(i + 1);
            startTim.Remove(i);
        }
    }
}

void Calculate()
{
    int start = 0;
    int link = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (startTim.ContainsKey(i + 1) && startTim.ContainsKey(j + 1))
            {
                start += arr[i, j];
            }

            if (!startTim.ContainsKey(i + 1) && !startTim.ContainsKey(j + 1))
            {
                link += arr[i, j];
            }
        }
    }

    if (min > Math.Abs(start - link))
    {
        min = (int)Math.Abs(start - link);
    }
}