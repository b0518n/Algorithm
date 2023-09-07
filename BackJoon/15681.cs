int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 정점의 수
int r = input[1]; // 루트의 번호
int q = input[2]; // 쿼리의 수

int u = 0;
int v = 0;

List<List<int>> list = new List<List<int>>();

for (int i = 0; i < n + 1; i++)
{
    list.Add(new List<int>());
}

for (int i = 0; i < n - 1; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    u = input[0];
    v = input[1];

    list[u].Add(v);
    list[v].Add(u);
}

List<int> vertexs = new List<int>();

for (int i = 0; i < q; i++)
{
    vertexs.Add(int.Parse(Console.ReadLine()));
}

int[] dp = new int[n + 1];
int[] visited = new int[n + 1];

DFS(r, dp, visited, list);

StringBuilder sb = new StringBuilder();

for (int i = 0; i < vertexs.Count; i++)
{
    sb.AppendLine(dp[vertexs[i]].ToString());
}

Console.WriteLine(sb.ToString());

void DFS(int root, int[] dp, int[] visited, List<List<int>> list)
{
    visited[root] = 1;
    dp[root] = 1;

    foreach (int i in list[root])
    {
        if (visited[i] == 0)
        {
            DFS(i, dp, visited, list);
            dp[root] += dp[i];
        }
    }
}