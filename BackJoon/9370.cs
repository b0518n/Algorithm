StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
int[] input = null;

int n = 0; // 교차로 후보의 개수
int m = 0; // 도로 후보의 개수
int k = 0; // 목적지 후보의 개수

int s = 0; // 출발지
int g = 0;
int h = 0;

int a = 0;
int b = 0;
int d = 0;

Dictionary<int, int> destinations = null;
List<List<int[]>> list = null;
int[] lengths = null;
int[] lengths_gh = null; // g에서 h로
int[] lengths_hg = null; // h에서 g로

int value = 0;
Dictionary<int, int> result = null;
int[] arr = null;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    m = input[1];
    k = input[2];

    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    s = input[0];
    g = input[1];
    h = input[2];

    list = new List<List<int[]>>();

    for (int j = 0; j < n + 1; j++)
    {
        list.Add(new List<int[]>());
    }

    for (int j = 0; j < m; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        a = input[0];
        b = input[1];
        d = input[2];

        list[a].Add(new int[2] { b, d });
        list[b].Add(new int[2] { a, d });
    }

    destinations = new Dictionary<int, int>();

    for (int j = 0; j < k; j++)
    {
        destinations.Add(int.Parse(Console.ReadLine()), 1);
    }

    lengths = Dijstra(list, n, s);
    lengths_gh = Solve(list, n, g, h);
    lengths_hg = Solve(list, n, h, g);


    value = 0;
    result = new Dictionary<int, int>();

    // 목적지 까지 우회하지 않고 최단거리로 갈 것이라 확신한다 = s에서 목적지 까지의 최단거리와 g - h 거리를 거치는 최단거리가 동일해야 됨
    // s에서 목적지 까지의 거리와 1. s -> g -> h -> 목적지, 2. s-> h -> g -> 목적지 값이 동일한 지를 비교.
    foreach (int tmp in destinations.Keys)
    {
        value = lengths[g] + lengths_gh[tmp];

        if (lengths_gh[tmp] != 0)
        {
            if (lengths[tmp] == value && !result.ContainsKey(tmp))
            {
                result.Add(tmp, 1);
            }
        }

        value = lengths[h] + lengths_hg[tmp];

        if (lengths_hg[tmp] != 0)
        {
            if (lengths[tmp] == value && !result.ContainsKey(tmp))
            {
                result.Add(tmp, 1);
            }
        }
    }

    arr = result.Keys.ToArray();
    Array.Sort(arr);

    if (arr.Length == 1)
    {
        sw.WriteLine(arr[0]);
    }
    else
    {
        for (int j = 0; j < arr.Length; j++)
        {
            if (j == 0)
            {
                sw.Write(arr[j]);
            }
            else if (j == arr.Length - 1)
            {
                sw.WriteLine(" " + arr[j]);
            }
            else
            {
                sw.Write(" " + arr[j]);
            }
        }
    }
}

sw.Flush();
sw.Close();

int[] Dijstra(List<List<int[]>> list, int vertexs, int start)
{
    int[] visited = new int[vertexs + 1];
    int[] lengths = new int[vertexs + 1];
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited[start] = 1;

    int tmp = 0;
    int min = int.MaxValue;
    int index = -1;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();
        min = int.MaxValue;
        index = -1;

        foreach (int[] temp in list[tmp])
        {
            if (temp[0] == start)
            {
                continue;
            }

            if (lengths[temp[0]] == 0)
            {
                lengths[temp[0]] = lengths[tmp] + temp[1];
            }
            else
            {
                if (lengths[temp[0]] > lengths[tmp] + temp[1])
                {
                    lengths[temp[0]] = lengths[tmp] + temp[1];
                }
            }
        }

        for (int i = 1; i < vertexs + 1; i++)
        {
            if (min > lengths[i] && lengths[i] != 0 && visited[i] != 1)
            {
                min = lengths[i];
                index = i;
            }
        }

        if (index != -1)
        {
            queue.Enqueue(index);
            visited[index] = 1;
        }
    }

    return lengths;
}

// a에서 b로 이동 후 다익스트라 알고리즘 이용하는 함수
int[] Solve(List<List<int[]>> list, int vertexs, int a, int b)
{
    int[] visited = new int[vertexs + 1];
    int[] lengths = new int[vertexs + 1];
    Queue<int> queue = new Queue<int>();
    visited[a] = 1;
    visited[b] = 1;
    foreach (int[] t in list[a])
    {
        if (t[0] == b)
        {
            lengths[b] = t[1];
            break;
        }
    }

    queue.Enqueue(b);

    int tmp = 0;
    int min = int.MaxValue;
    int index = -1;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();
        min = int.MaxValue;
        index = -1;

        foreach (int[] temp in list[tmp])
        {
            if (temp[0] == a)
            {
                continue;
            }

            if (lengths[temp[0]] == 0)
            {
                lengths[temp[0]] = lengths[tmp] + temp[1];
            }
            else
            {
                if (lengths[temp[0]] > lengths[tmp] + temp[1])
                {
                    lengths[temp[0]] = lengths[tmp] + temp[1];
                }
            }
        }

        for (int i = 1; i < vertexs + 1; i++)
        {
            if (min > lengths[i] && lengths[i] != 0 && visited[i] != 1)
            {
                min = lengths[i];
                index = i;
            }
        }

        if (index != -1)
        {
            queue.Enqueue(index);
            visited[index] = 1;
        }
    }

    return lengths;
}