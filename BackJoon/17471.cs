StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] population = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int[] input = null;
List<List<int>> list = new List<List<int>>();

for (int i = 0; i < n; i++)
{
    list.Add(new List<int>());
}

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < input[0]; j++)
    {
        list[i].Add(input[j + 1] - 1);
    }
}

Dictionary<string, int> cases = new Dictionary<string, int>();
for (int i = 1; i < n; i++)
{
    Combination(n, i, new List<int>(), 0);
}

int max = 0;
CalulateMax();
int value = 0;
int[] arr = null;
int result = int.MaxValue;

if (cases.Count == 0)
{
    result = -1;
}
else
{
    foreach (string key in cases.Keys)
    {
        value = 0;
        arr = Array.ConvertAll(key.Split(), int.Parse);
        foreach (int i in arr)
        {
            value += population[i];
        }

        result = Math.Min(result, Math.Abs((max - value) - value));
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

void CalulateMax()
{
    foreach (int i in population)
    {
        max += i;
    }
}

void Combination(int _n, int _r, List<int> container, int index)
{
    if (container.Count == _r)
    {
        List<int> temp = DeepCopy(container);
        temp.Sort();

        if (IsConnected(temp) && IsDivideTwoSection(temp) && !cases.ContainsKey(string.Join(" ", temp)))
        {
            cases.Add(string.Join(" ", temp), 1);
        }
    }

    for (int i = index; i < n; i++)
    {
        container.Add(i);
        Combination(_n, _r, container, i + 1);
        container.RemoveAt(container.Count - 1);
    }
}

List<int> DeepCopy(List<int> container)
{
    List<int> tempList = new List<int>();

    for (int i = 0; i < container.Count; i++)
    {
        tempList.Add(container[i]);
    }

    return tempList;
}

bool IsConnected(List<int> container)
{
    Dictionary<int, int> dics = new Dictionary<int, int>();
    for (int i = 1; i < container.Count; i++)
    {
        dics.Add(container[i], 1);
    }

    Queue<int> queue = new Queue<int>();
    queue.Enqueue(container[0]);
    int temp = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        foreach (int i in list[temp])
        {
            if (!dics.ContainsKey(i))
            {
                continue;
            }

            dics.Remove(i);
            queue.Enqueue(i);
        }
    }

    if (dics.Count == 0)
    {
        return true;
    }

    return false;
}

bool IsDivideTwoSection(List<int> container)
{
    int[] visited = new int[n];
    foreach (int i in container)
    {
        visited[i] = 1;
    }

    for (int i = 0; i < n; i++)
    {
        if (visited[i] == 1)
        {
            continue;
        }

        BFS(i, visited);
        bool isTwoSection = true;
        for (int j = 0; j < n; j++)
        {
            if (visited[j] == 1)
            {
                continue;
            }

            isTwoSection = false;
        }

        if (isTwoSection)
        {
            return true;
        }
        else
        {
            break;
        }
    }

    return false;
}

void BFS(int index, int[] visited)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(index);
    visited[index] = 1;
    int temp = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        foreach (int i in list[temp])
        {
            if (visited[i] == 1)
            {
                continue;
            }

            queue.Enqueue(i);
            visited[i] = 1;
        }
    }
}