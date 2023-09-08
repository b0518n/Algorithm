int n = int.Parse(Console.ReadLine());

int[] weight = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

string str = null;
int[] input = null;

List<List<int>> lines = new List<List<int>>();

for (int i = 0; i < n + 1; i++)
{
    lines.Add(new List<int>());
}

while (true)
{
    str = Console.ReadLine();
    if (str == null || str == string.Empty)
    {
        break;
    }

    input = Array.ConvertAll(str.Split(), int.Parse);
    lines[input[0]].Add(input[1]);
    lines[input[1]].Add(input[0]);
}

int[,] dp = new int[n + 1, 2];
int[] visited = new int[n + 1];
List<int> vertexs = new List<int>();
int result = 0;

DFS(dp, lines, 1, weight, visited);
if (dp[1, 0] > dp[1, 1])
{
    result = dp[1, 0];
    SearchRoute(dp, 0, 0, 1, lines, vertexs);
}
else
{
    result = dp[1, 1];
    vertexs.Add(1);
    SearchRoute(dp, 1, 0, 1, lines, vertexs);
}

vertexs.Sort();

StringBuilder sb = new StringBuilder();
sb.AppendLine(result.ToString());
sb.AppendLine(string.Join(" ", vertexs));

Console.WriteLine(sb.ToString());

void DFS(int[,] dp, List<List<int>> lines, int index, int[] weight, int[] visited)
{
    dp[index, 0] = 0;
    dp[index, 1] = weight[index - 1];
    visited[index] = 1;

    foreach (int i in lines[index])
    {
        if (visited[i] == 1)
        {
            continue;
        }

        DFS(dp, lines, i, weight, visited);
        dp[index, 0] += Math.Max(dp[i, 0], dp[i, 1]);
        dp[index, 1] += dp[i, 0];

    }
}

void SearchRoute(int[,] dp, int flag, int parentIndex, int index, List<List<int>> lines, List<int> vertexs)
{
    if (flag == 1)
    {
        foreach (int i in lines[index])
        {
            if (parentIndex == i)
            {
                continue;
            }

            SearchRoute(dp, 0, index, i, lines, vertexs);
        }
    }
    else
    {
        foreach (int i in lines[index])
        {
            if (parentIndex == i)
            {
                continue;
            }

            if (dp[i, 0] > dp[i, 1])
            {
                SearchRoute(dp, 0, index, i, lines, vertexs);
            }
            else
            {
                vertexs.Add(i);
                SearchRoute(dp, 1, index, i, lines, vertexs);
            }
        }
    }
}