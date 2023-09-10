int n = int.Parse(Console.ReadLine());
int[] populations = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

List<List<int>> routes = new List<List<int>>();

for (int i = 0; i < n + 1; i++)
{
    routes.Add(new List<int>());
}

int[] input = null;

for (int i = 0; i < n - 1; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    routes[input[1]].Add(input[0]);
    routes[input[0]].Add(input[1]);
}

int[,] dp = new int[n + 1, 2];
DFS(routes, populations, dp, 1, 0);

Console.WriteLine(Math.Max(dp[1, 0], dp[1, 1]));

void DFS(List<List<int>> routes, int[] populations, int[,] dp, int city, int previousCity)
{
    dp[city, 0] = 0;
    dp[city, 1] = populations[city - 1];

    foreach (int temp in routes[city])
    {
        if (temp == previousCity)
        {
            continue;
        }

        DFS(routes, populations, dp, temp, city);
        dp[city, 0] += Math.Max(dp[temp, 0], dp[temp, 1]);
        dp[city, 1] += dp[temp, 0];

    }
}