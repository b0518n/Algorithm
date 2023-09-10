int n = int.Parse(Console.ReadLine());
int[] input = null;

List<List<int>> edges = new List<List<int>>();

for (int i = 0; i < n + 1; i++)
{
    edges.Add(new List<int>());
}

for (int i = 0; i < n - 1; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    edges[input[0]].Add(input[1]);
    edges[input[1]].Add(input[0]);
}

int[,] dp = new int[n + 1, 2]; // dp[v,0] : 정점 v가 얼리 아답터가 아닐 경우, dp[v,1] : 정점 v가 얼리 아답터일 경우
DFS(edges, dp, 1, 0);

Console.WriteLine(Math.Min(dp[1, 0], dp[1, 1]));

 void DFS(List<List<int>> edges, int[,] dp, int vertex, int previousVertex)
{
    dp[vertex, 0] = 0;
    dp[vertex, 1] = 1;

    foreach (int i in edges[vertex])
    {
        if (i == previousVertex)
        {
            continue;
        }


        // vertex가 얼리 어답터가 아닐경우 : i는 무조건 얼리 어답터
        // vertex가 얼리 어답터일 경우 : i는 얼리 어답터이거나 얼리 어답터가 아님
        DFS(edges, dp, i, vertex);
        dp[vertex, 0] += dp[i, 1];
        dp[vertex, 1] += Math.Min(dp[i, 0], dp[i, 1]);
    }
}