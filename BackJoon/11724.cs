int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int u = 0;
int v = 0;

List<List<int>> graph = new List<List<int>>();
int[] visited = new int[n + 1];

for (int i = 0; i < n + 1; i++)
{
    graph.Add(new List<int>());
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    u = input[0];
    v = input[1];

    graph[u].Add(v);
    graph[v].Add(u);
}

int result = 0;

for (int i = 1; i < n + 1; i++)
{
    if (visited[i] == 1)
    {
        continue;
    }

    BFS(i);
}

Console.WriteLine(result);

void BFS(int index)
{
    visited[index] = 1;
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(index);

    int temp = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        foreach (int i in graph[temp])
        {
            if (visited[i] == 1)
            {
                continue;
            }

            queue.Enqueue(i);
            visited[i] = 1;
        }
    }

    result++;
}