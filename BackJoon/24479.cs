StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int r = input[2];

List<int>[] list = new List<int>[n + 1];

int u = 0;
int v = 0;
for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    u = input[0];
    v = input[1];

    if (list[u] == null)
    {
        list[u] = new List<int>();
    }

    if (list[v] == null)
    {
        list[v] = new List<int>();
    }

    list[u].Add(v);
    list[v].Add(u);
}

for (int i = 1; i <= n; i++)
{
    if (list[i] != null)
    {
        list[i].Sort();
        list[i].Reverse();
    }
}

int[] visited = new int[n + 1];

int count = 1;
visited[r] = 1;
DFS(visited, r, list);

for (int i = 1; i <= n; i++)
{
    sw.WriteLine(visited[i]);
}

sw.Flush();
sw.Close();

void DFS(int[] visited, int start, List<int>[] list)
{
    int index = 0;

    while (list[start] != null && list[start].Count > 0)
    {
        index = list[start][list[start].Count - 1];
        list[start].RemoveAt(list[start].Count - 1);

        // 무방향 그래프이므로 이미 방문한 곳을 또 방문할 가능성이 있음
        // 그때마다 count의 크기를 키우거나 visited에 방문 기록을 하지 않기 위해서 0인경우에만 수행하도록 함.
        if (visited[index] == 0)
        {
            count++;
            visited[index] = count;
            DFS(visited, index, list);
        }
    }
}