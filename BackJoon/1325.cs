int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
Computer[] computers = new Computer[n + 1];
int[] cnts = new int[n + 1];
List<int> result = new List<int>();
int max = -1;

for (int i = 1; i < n + 1; i++)
{
    computers[i] = new Computer(new Dictionary<int, int>());
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    computers[input[1]].AddRelation(input[0]);
}

for (int i = 1; i < n + 1; i++)
{
    BFS(i);
}

for (int i = 1; i < n + 1; i++)
{
    if (max == -1)
    {
        max = cnts[i];
        result.Add(i);
    }
    else
    {
        if (max < cnts[i])
        {
            max = cnts[i];
            result.Clear();
            result.Add(i);
        }
        else if (max == cnts[i])
        {
            result.Add(i);
        }
    }
}

result.Sort();
Console.WriteLine(string.Join(" ", result));

void BFS(int index)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(index);
    int[] visited = new int[n + 1];
    visited[index] = 1;
    int temp = 0;
    int cnt = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        foreach (int key in computers[temp].relations.Keys)
        {
            if (visited[key] == 1)
            {
                continue;
            }

            q.Enqueue(key);
            visited[key] = 1;
            cnt++;
        }
    }

    cnts[index] = cnt;
}

class Computer
{
    public Dictionary<int, int> relations = null;

    public Computer(Dictionary<int, int> computers)
    {
        this.relations = computers;
    }

    public void AddRelation(int index)
    {
        if (!relations.ContainsKey(index))
        {
            relations.Add(index, 1);
        }
    }
}