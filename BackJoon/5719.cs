StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = null;
int n = 0;
int m = 0;
int s = 0;
int d = 0;

int[] minDistanceArr = null;
MinHeap pq = new MinHeap();
int[,] roads = null;
Info temp = null;

int[] visited = null;

while (true)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    n = input[0];
    m = input[1];

    if (n == 0 && m == 0)
        break;

    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    s = input[0];
    d = input[1];

    minDistanceArr = new int[n];
    roads = new int[n, n];
    visited = new int[n];

    for (int i = 0; i < n; i++)
    {
        minDistanceArr[i] = -1;
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == j)
                continue;
            roads[i, j] = -1;
        }
    }

    for (int i = 0; i < m; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        roads[input[0], input[1]] = input[2];
    }

    Dijkstra();
    DeleteRoad(s, d);

    for (int i = 0; i < n; i++)
    {
        minDistanceArr[i] = -1;
        visited[i] = 0;
    }

    Dijkstra();

    sw.WriteLine(minDistanceArr[d]);
}

sw.Flush();
sw.Close();

void Dijkstra()
{
    pq.Push(new Info(s, 0));
    minDistanceArr[s] = 0;
    Info temp = null;

    while (pq.count > 0)
    {
        temp = pq.Peek();
        pq.Pop();

        visited[temp.destination] = 1;

        for (int i = 0; i < n; i++)
        {
            if (visited[i] == 1)
                continue;
            if (roads[temp.destination, i] == -1)
                continue;
            if (temp.destination == i)
                continue;

            if (minDistanceArr[i] == -1)
            {
                minDistanceArr[i] = temp.dist + roads[temp.destination, i];
                pq.Push(new Info(i, temp.dist + roads[temp.destination, i]));
            }
            else
            {
                if (minDistanceArr[i] > temp.dist + roads[temp.destination, i])
                {
                    minDistanceArr[i] = temp.dist + roads[temp.destination, i];
                    pq.Push(new Info(i, temp.dist + roads[temp.destination, i]));
                }
            }


        }
    }
}
void DeleteRoad(int _start, int _end)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(_end);

    int temp = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        if (temp == _start)
            continue;

        for (int i = 0; i < n; i++)
        {
            if (roads[i, temp] == -1)
                continue;
            if (i == temp)
                continue;

            if (minDistanceArr[temp] == minDistanceArr[i] + roads[i, temp])
            {
                roads[i, temp] = -1;
                q.Enqueue(i);
            }
        }
    }
}

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
        if (count != 1)
        {
            Swap(0, count - 1);
            container.RemoveAt(count - 1);
            count--;
            HeapifyDown(0);
        }
        else
        {
            container.RemoveAt(count - 1);
            count--;
        }
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
        return new Info(container[0].destination, container[0].dist);
    }
    public void Swap(int index1, int index2)
    {
        Info temp = container[index1];
        container[index1] = container[index2];
        container[index2] = temp;
    }
}