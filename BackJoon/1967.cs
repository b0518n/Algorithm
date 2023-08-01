StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());

int[] input = null;

int a = 0;
int b = 0;
int c = 0;

int[] costs = new int[n + 1];

for (int i = 1; i < n + 1; i++)
{
    costs[i] = int.MaxValue;
}

List<List<int[]>> graph = new List<List<int[]>>();

for (int i = 0; i < n + 1; i++)
{
    graph.Add(new List<int[]>());
}

for (int i = 1; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    graph[a].Add(new int[2] { b, c });
    graph[b].Add(new int[2] { a, c });
}

costs[1] = 0;
DFS(1);

int max = -1;
int index = -1;
for (int i = 1; i < costs.Length; i++)
{
    if (max < costs[i])
    {
        max = costs[i];
        index = i;
    }
}

costs = new int[n + 1];
for (int i = 1; i < n + 1; i++)
{
    costs[i] = int.MaxValue;
}

costs[index] = 0;
DFS(index);

sw.WriteLine(costs.Max());
sw.Flush();
sw.Close();

void DFS(int start)
{
    foreach (int[] temp in graph[start])
    {
        if (costs[temp[0]] == int.MaxValue)
        {
            costs[temp[0]] = costs[start] + temp[1];
            DFS(temp[0]);
        }
    }
}