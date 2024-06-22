StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] distanceArr = new int[n + 1];
int[] beforeComputers = new int[n + 1];
List<Dictionary<int, int>> routeList = new List<Dictionary<int, int>>();

for (int i = 2; i < n + 1; i++)
{
    distanceArr[i] = int.MaxValue;
}

for (int i = 0; i < n + 1; i++)
{
    routeList.Add(new Dictionary<int, int>());
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    routeList[input[0]].Add(input[1], input[2]);
    routeList[input[1]].Add(input[0], input[2]);
}

Dijkstra();
sw.WriteLine(n - 1);
for (int i = 2; i < n + 1; i++)
{
    sw.WriteLine($"{i} {beforeComputers[i]}");
}
sw.Flush();
sw.Close();

void Dijkstra()
{
    int[] visited = new int[n + 1];
    MinHeap pq = new MinHeap();
    pq.Push(1, 0);

    RouteInfo temp = null;

    while (pq.count > 0)
    {
        temp = pq.Peek();
        pq.Pop();
        if (visited[temp.destination] == 1)
            continue;

        visited[temp.destination] = 1;

        foreach (int key in routeList[temp.destination].Keys)
        {
            if (distanceArr[key] == int.MaxValue)
            {
                distanceArr[key] = temp.distance + routeList[temp.destination][key];
                pq.Push(key, temp.distance + routeList[temp.destination][key]);
                beforeComputers[key] = temp.destination;
            }
            else
            {
                if (distanceArr[key] > temp.distance + routeList[temp.destination][key])
                {
                    distanceArr[key] = temp.distance + routeList[temp.destination][key];
                    pq.Push(key, temp.distance + routeList[temp.destination][key]);
                    beforeComputers[key] = temp.destination;
                }
            }
        }
    }
}

class MinHeap
{
    public List<RouteInfo> container;
    public int count;

    public MinHeap()
    {
        this.container = new List<RouteInfo>();
        this.count = 0;
    }

    public void Push(int _destination, int _distance)
    {
        container.Add(new RouteInfo(_destination, _distance));
        count++;
        HeapifyUp(count - 1);
    }

    public RouteInfo Peek()
    {
        return container[0];
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
            if (container[parentIndex].distance > container[_index].distance)
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
        int minChildIndex = _index;

        if (leftChildIndex < count && container[leftChildIndex].distance < container[minChildIndex].distance)
        {
            minChildIndex = leftChildIndex;
        }

        if (rightChildIndex < count && container[rightChildIndex].distance < container[minChildIndex].distance)
        {
            minChildIndex = rightChildIndex;
        }

        if (minChildIndex != _index)
        {
            Swap(minChildIndex, _index);
            HeapifyDown(minChildIndex);
        }

        return;
    }

    public void Swap(int _index1, int _index2)
    {
        RouteInfo temp = container[_index1];
        container[_index1] = container[_index2];
        container[_index2] = temp;

        return;
    }


}
class RouteInfo
{
    public int destination;
    public int distance;

    public RouteInfo(int _destination, int _distance)
    {
        this.destination = _destination;
        this.distance = _distance;
    }
}