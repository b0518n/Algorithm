SortedDictionary<int, List<int>> priorityQueue = new SortedDictionary<int, List<int>>();
int n = int.Parse(Console.ReadLine());
int value = 0;

for (int i = 0; i < n; i++)
{
    value = int.Parse(Console.ReadLine());
    if (!priorityQueue.ContainsKey(value))
    {
        priorityQueue.Add(value, new List<int>() { 1 });
    }
    else
    {
        priorityQueue[value].Add(i);
    }
}

int result = 0;

while (true)
{
    if (n == 1)
    {
        break;
    }

    solve();
    n -= 1;
}

Console.WriteLine(result);

void solve()
{
    value = 0;
    value += priorityQueue.First().Key;
    priorityQueue.First().Value.RemoveAt(priorityQueue.First().Value.Count - 1);
    if (priorityQueue.First().Value.Count == 0)
    {
        priorityQueue.Remove(priorityQueue.First().Key);
    }

    value += priorityQueue.First().Key;
    priorityQueue.First().Value.RemoveAt(priorityQueue.First().Value.Count - 1);
    if (priorityQueue.First().Value.Count == 0)
    {
        priorityQueue.Remove(priorityQueue.First().Key);
    }

    result += value;
    if (!priorityQueue.ContainsKey(value))
    {
        priorityQueue.Add(value, new List<int>() { 1 });
    }
    else
    {
        priorityQueue[value].Add(1);
    }

    value = 0;
}