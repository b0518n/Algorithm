StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int n = input[0]; // 정점의 개수
int e = input[1]; // 간선의 개수

// a에서 b로, b에서 a로 (무방향 그래프), c : 비용
int a = 0;
int b = 0;
int c = 0;

List<List<int[]>> list = new List<List<int[]>>();

for (int i = 0; i < n + 1; i++)
{
    list.Add(new List<int[]>());
}

for (int i = 0; i < e; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    a = input[0];
    b = input[1];
    c = input[2];

    list[a].Add(new int[2] { b, c });
    list[b].Add(new int[2] { a, c });

}

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

// 반드시 거쳐야 하는 정점 , u와 v사이의 간선은 최대 1개 존재 = 없을 수도 있을 수도 있음.
int v1 = input[0];
int v2 = input[1];

//
Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();

for (int i = 0; i < n + 1; i++)
{
    dic.Add(i, new Dictionary<int, int>());
}

int[] costs_start = Dijksta(list, 1);
int[] costs_v1 = Dijksta(list, v1);
int[] costs_v2 = Dijksta(list, v2);

int result = -1;

// 1. start -> v1 -> v2 -> n
if (costs_start[v1] != int.MaxValue && costs_v1[v2] != int.MaxValue && costs_v2[n] != int.MaxValue)
{
    result = costs_start[v1] + costs_v1[v2] + costs_v2[n];
}

// 2. start -> v2 -> v1 -> n
if (costs_start[v2] != int.MaxValue && costs_v2[v1] != int.MaxValue && costs_v1[n] != int.MaxValue)
{
    if (result == -1)
    {
        result = costs_start[v2] + costs_v2[v1] + costs_v1[n];
    }
    else
    {
        if (result > costs_start[v2] + costs_v2[v1] + costs_v1[n])
        {
            result = costs_start[v2] + costs_v2[v1] + costs_v1[n];
        }
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

int[] Dijksta(List<List<int[]>> list, int start)
{
    Queue<int> queue = new Queue<int>();
    int[] visited = new int[n + 1];
    int[] arr = new int[n + 1];

    queue.Enqueue(start);
    int tmp = 0;

    int min = 800001;
    int index = -1;

    while (queue.Count > 0)
    {
        tmp = queue.Dequeue();
        visited[tmp] = 1;
        foreach (int[] temp in list[tmp])
        {
            if (arr[temp[0]] == 0)
            {
                arr[temp[0]] = arr[tmp] + temp[1];
            }
            else
            {
                if (arr[temp[0]] > arr[tmp] + temp[1])
                {
                    arr[temp[0]] = arr[tmp] + temp[1];
                }
            }
        }

        min = int.MaxValue;
        index = -1;

        for (int i = 1; i < n + 1; i++)
        {
            if (arr[i] != 0)
            {
                if (min > arr[i] && visited[i] == 0)
                {
                    min = arr[i];
                    index = i;
                }
            }
        }

        if (index != -1)
        {
            queue.Enqueue(index);
        }
    }

    // 도달할 수 없는 정점의 비용을 int.maxValue로 값을 바꾸어 구분하는 용도로 사용
    for (int i = 1; i < n + 1; i++)
    {
        if (i == start)
        {
            arr[i] = 0;
        }
        else
        {
            if (arr[i] == 0)
            {
                arr[i] = int.MaxValue;
            }
        }
    }

    return arr;
}