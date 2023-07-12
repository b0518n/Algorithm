StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int r = input[2];

int[] visited = new int[n + 1];
List<int>[] graph = new List<int>[n + 1];
Queue<int> queue = new Queue<int>();

for (int i = 0; i < n + 1; i++)
{
    graph[i] = new List<int>();
}

int u = 0;
int v = 0;

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    u = input[0];
    v = input[1];

    // 무방향 그래프
    graph[u].Add(v);
    graph[v].Add(u);

}

for (int i = 1; i < n + 1; i++)
{
    if (graph[i] != null)
    {
        graph[i].Sort();
    }
}

int count = 0;
BFS(graph, r);

for (int i = 1; i < n + 1; i++)
{
    sw.WriteLine(visited[i]);
}

sw.Flush();
sw.Close();

// BFS의 경우 큐 자료구조를 이용해서 큐에 넣을 때 방문 체크를 하는 식으로 구현
void BFS(List<int>[] graph, int start)
{
    count++;
    visited[start] = count;
    queue.Enqueue(start);
    int index = 0;

    while (queue.Count > 0)
    {
        index = queue.Dequeue();

        for (int i = graph[index].Count - 1; i >= 0; i--)
        {
            if (visited[graph[index][i]] == 0)
            {
                count++;
                visited[graph[index][i]] = count;
                queue.Enqueue(graph[index][i]);
            }
        }
    }
}