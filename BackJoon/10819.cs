int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
bool[] visited = new bool[arr.Length];
int[] order = new int[arr.Length];
int max = 0;
Recursion(0);
Console.WriteLine(max);

void Recursion(int k)
{
    if (k == n)
    {
        Calculate();
        return;
    }

    for (int i = 0; i < n; i++)
    {
        if (visited[i])
        {
            continue;
        }

        visited[i] = true;
        order[k] = i;
        Recursion(k + 1);
        visited[i] = false;

    }
}

void Calculate()
{
    int value = 0;

    for (int i = 0; i < n - 1; i++)
    {
        value += Math.Abs(arr[order[i]] - arr[order[i + 1]]);
    }

    max = Math.Max(max, value);
}