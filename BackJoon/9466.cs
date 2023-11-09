int t = int.Parse(Console.ReadLine());
int n = 0;
int[] input = null;
int[] dp = null;
int[] visited = null;
int count = 0;

for (int i = 0; i < t; i++)
{
    n = int.Parse(Console.ReadLine());
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    dp = new int[n + 1];
    visited = new int[n + 1];
    count = 0;

    for (int j = 0; j < n; j++)
    {
        dp[j + 1] = input[j];
    }

    for (int k = 1; k < n + 1; k++)
    {
        if (visited[k] == 0)
        {
            DFS(k);
        }
    }

    for (int k = 1; k < n + 1; k++)
    {
        if (visited[k] != -1)
        {
            count++;
        }
    }

    Console.WriteLine(count);
}

void DFS(int index)
{
    int _index = index;

    while (true)
    {
        if (visited[_index] != 0)
        {
            while (visited[_index] != -1 && visited[_index] == index)
            {
                visited[_index] = -1;
                _index = dp[_index];
            }
            return;
        }
        visited[_index] = index;
        _index = dp[_index];
    }
}