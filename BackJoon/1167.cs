StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int v = int.Parse(Console.ReadLine()); // 정점의 개수
int[] input = null;

int a = 0;
int b = 0;
int c = 0;

// Floyd_Warshall - 메모리 초과
// Dijstra - 루트 노드를 모르기 때문에 불가능
// Bellman_Ford - 양의 가중치가 없는데 사용이유가 없으며, 다익스트라와 마찬가지로 시작점을 모르기 떄문에 사용불가
// 트리의 아무 정점에서 DFS를 한번 수행한 뒤 가장 거리가 먼 곳을 기준으로 다시 DFS를 수행
// 거리가 가장 먼 경우는 루트로부터 거리가 가장 먼 터미널 노드이거나 또는 루트노드 둘 중 하나의 vertax를 얻을 수 있음 
List<List<int[]>> graph = new List<List<int[]>>();
int[] visited = new int[v + 1];
int[] costs = new int[v + 1];

for (int i = 0; i < v + 1; i++)
{
    graph.Add(new List<int[]>());
}

int index = 1;
for (int i = 0; i < v; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];

    index = 1;
    while (true)
    {
        b = input[index];
        if (b == -1)
        {
            break;
        }
        else
        {
            index++;
            c = input[index];
        }

        graph[a].Add(new int[2] { b, c });
        index++;
    }
}

DFS(1);

int max = -1;
int vertax = -1;
for (int i = 1; i < v + 1; i++)
{
    if (max < costs[i])
    {
        max = costs[i];
        vertax = i;
    }
}

visited = new int[v + 1];
costs = new int[v + 1];
DFS(vertax);

max = -1;
vertax = -1;
for (int i = 1; i < v + 1; i++)
{
    if (max < costs[i])
    {
        max = costs[i];
        vertax = i;
    }
}

sw.Write(max);
sw.Flush();
sw.Close();

void DFS(int start)
{
    visited[start] = 1;

    foreach (int[] temp in graph[start])
    {
        if (visited[temp[0]] == 1)
        {
            continue;
        }

        costs[temp[0]] = costs[start] + temp[1];
        DFS(temp[0]);
    }
}