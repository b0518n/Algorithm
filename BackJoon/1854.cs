StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];

List<List<int>> list = new List<List<int>>();
MinHeap pq = new MinHeap();

for (int i = 0; i < n + 1; i++)
{
    list.Add(new List<int>());
}

Dictionary<int, List<Info>> roads = new Dictionary<int, List<Info>>();
for (int i = 1; i < n + 1; i++)
{
    roads.Add(i, new List<Info>());
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    roads[input[0]].Add(new Info(input[1], input[2]));
}

pq.Push(new Info(1, 0));
Info temp = null;
int dest = 0;
int dist = 0;

while (pq.count > 0)
{
    temp = pq.Peek();
    dest = temp.destination;
    dist = temp.dist;

    pq.Pop();
    if (list[dest].Count >= k)
        continue;

    list[dest].Add(dist);

    foreach (Info info in roads[dest])
    {
        pq.Push(new Info(info.destination, dist + info.dist));
    }
}

for (int i = 1; i < n + 1; i++)
{
    if (list[i].Count < k)
    {
        sw.WriteLine(-1);
    }
    else
    {
        sw.WriteLine(list[i][k - 1]);
    }
}

sw.Flush();
sw.Close();

class Info
{
    public int destination;
    public int dist;

    public Info(int _destination, int _dist)
    {
        this.destination = _destination;
        this.dist = _dist;
    }
}

class MinHeap
{
    List<Info> container;
    public int count;

    public MinHeap()
    {
        container = new List<Info>();
        count = 0;
    }

    public void Push(Info _info)
    {
        container.Add(_info);
        count++;
        HeapifyUp(count - 1);
    }

    public void Pop()
    {
        Swap(0, count - 1);
        container.RemoveAt(count - 1);
        count--;
        HeapifyDown(0);
    }

    public void HeapifyUp(int _index)
    {
        int parentIndex = (_index - 1) / 2;

        while (parentIndex != _index)
        {
            if (container[parentIndex].dist > container[_index].dist)
            {
                Swap(parentIndex, _index);
                _index = parentIndex;
                parentIndex = (_index - 1) / 2;
            }
            else
            {
                break;
            }
        }
    }

    public void HeapifyDown(int _index)
    {
        int leftChildIndex = (2 * _index) + 1;
        int rightChildIndex = (2 * _index) + 2;
        int smallestChildIndex = _index;

        if (leftChildIndex < count && container[leftChildIndex].dist < container[smallestChildIndex].dist)
        {
            smallestChildIndex = leftChildIndex;
        }

        if (rightChildIndex < count && container[rightChildIndex].dist < container[smallestChildIndex].dist)
        {
            smallestChildIndex = rightChildIndex;
        }

        if (_index != smallestChildIndex)
        {
            Swap(_index, smallestChildIndex);
            HeapifyDown(smallestChildIndex);
        }
    }

    public Info Peek()
    {
        if (container.Count == 0)
            return new Info(-1, -1);
        return container[0];
    }

    public void Swap(int index1, int index2)
    {
        Info temp = new Info(container[index1].destination, container[index1].dist);
        container[index1].destination = container[index2].destination;
        container[index1].dist = container[index2].dist;
        container[index2].destination = temp.destination;
        container[index2].dist = temp.dist;
    }
}