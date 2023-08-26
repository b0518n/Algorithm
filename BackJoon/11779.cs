int n = int.Parse(Console.ReadLine()); // 도시의 개수
int m = int.Parse(Console.ReadLine()); // 버스의 개수
int[] input = null;
List<int[]>[] routes = new List<int[]>[n + 1];
int[] cost = new int[n + 1];
int[] visited = new int[n + 1];
int[] beforeIndex = new int[n + 1];

for (int i = 0; i < n + 1; i++)
{
    cost[i] = int.MaxValue;
    routes[i] = new List<int[]>();
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    routes[input[0]].Add(new int[2] { input[1], input[2] });
}

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int start = input[0];
int end = input[1];

Dijkstra(start, cost, visited, routes, beforeIndex);
Print(cost, beforeIndex, end);

void Dijkstra(int start, int[] cost, int[] visited, List<int[]>[] routes, int[] beforeIndex)
{
    Queue<int> q = new Queue<int>();
    cost[start] = 0;
    q.Enqueue(start);

    int tmp = 0;
    int min = int.MaxValue;
    int index = -1;

    while (q.Count > 0)
    {
        tmp = q.Dequeue();
        visited[tmp] = 1;
        min = int.MaxValue;
        index = -1;

        foreach (int[] temp in routes[tmp])
        {
            if (cost[temp[0]] > cost[tmp] + temp[1])
            {
                cost[temp[0]] = cost[tmp] + temp[1];
                beforeIndex[temp[0]] = tmp;
            }
        }

        for (int i = 1; i < cost.Length; i++)
        {
            if (visited[i] == 1)
            {
                continue;
            }

            if (min > cost[i])
            {
                min = cost[i];
                index = i;
            }
        }

        if (index != -1)
        {
            q.Enqueue(index);
        }
    }
}

void Print(int[] cost, int[] beforeIndex, int end)
{
    StringBuilder sb = new StringBuilder();
    Stack<int> stack = new Stack<int>();
    int index = end;
    while (true)
    {
        if (beforeIndex[index] == 0)
        {
            break;
        }
        else if (index == end)
        {
            stack.Push(index);
            stack.Push(beforeIndex[index]);
            index = beforeIndex[index];
        }
        else
        {
            stack.Push(beforeIndex[index]);
            index = beforeIndex[index];
        }
    }

    sb.AppendLine(stack.Count.ToString());

    while (stack.Count > 0)
    {
        sb.Append(stack.Pop());
        if (stack.Count > 0)
        {
            sb.Append(" ");
        }
    }

    sb.Insert(0, cost[end] + "\n");

    Console.WriteLine(sb.ToString());
}