StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];

List<Dictionary<int, int>> routeList = new List<Dictionary<int, int>>();
long[,] minDisArr = new long[k + 1, n + 1];
int[,] visited = new int[k + 1, n + 1];

for (int i = 0; i < n + 1; i++)
{
    routeList.Add(new Dictionary<int, int>());
}

for (int i = 0; i < k + 1; i++)
{
    for (int j = 0; j < n + 1; j++)
    {
        if (j <= 1)
            continue;
        minDisArr[i, j] = int.MaxValue;
    }
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

    if (routeList[input[0]].ContainsKey(input[1]))
    {
        routeList[input[0]][input[1]] = Math.Min(routeList[input[0]][input[1]], input[2]);
    }
    else
    {
        routeList[input[0]].Add(input[1], input[2]);
    }

    if (routeList[input[1]].ContainsKey(input[0]))
    {
        routeList[input[1]][input[0]] = Math.Min(routeList[input[1]][input[0]], input[2]);
    }
    else
    {
        routeList[input[1]].Add(input[0], input[2]);
    }
}

Dijkstra();
long result = 0;
for (int i = 0; i < k + 1; i++)
{
    if (i == 0)
    {
        result = minDisArr[i, n];
    }
    else
    {
        result = Math.Min(result, minDisArr[i, n]);
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();


void Dijkstra()
{
    MinHeap pq = new MinHeap();
    pq.Push(1, 0, 0);
    RouteInfo temp = null;

    while (pq.count > 0)
    {
        temp = pq.Peek();
        pq.Pop();

        if (visited[temp.cnt, temp.destination] == 1)
        {
            continue;
        }

        visited[temp.cnt, temp.destination] = 1;
        foreach (int dest in routeList[temp.destination].Keys)
        {
            if (visited[temp.cnt, dest] != 1)
            {
                if (minDisArr[temp.cnt, dest] == int.MaxValue)
                {
                    minDisArr[temp.cnt, dest] = temp.distance + routeList[temp.destination][dest];
                    pq.Push(dest, temp.distance + routeList[temp.destination][dest], temp.cnt);
                }
                else
                {
                    if (minDisArr[temp.cnt, dest] > temp.distance + routeList[temp.destination][dest])
                    {
                        minDisArr[temp.cnt, dest] = temp.distance + routeList[temp.destination][dest];
                        pq.Push(dest, temp.distance + routeList[temp.destination][dest], temp.cnt);
                    }
                }
            }

            if (temp.cnt < k)
            {
                if (visited[temp.cnt + 1, dest] == 1)
                    continue;

                if (minDisArr[temp.cnt + 1, dest] == int.MaxValue)
                {
                    minDisArr[temp.cnt + 1, dest] = temp.distance;
                    pq.Push(dest, temp.distance, temp.cnt + 1);
                }
                else
                {
                    if (minDisArr[temp.cnt + 1, dest] > temp.distance)
                    {
                        minDisArr[temp.cnt + 1, dest] = temp.distance;
                        pq.Push(dest, temp.distance, temp.cnt + 1);
                    }
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

    public void Push(int _destination, long _distance, int _cnt)
    {
        container.Add(new RouteInfo(_destination, _distance, _cnt));
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
    public long distance;
    public int cnt;

    public RouteInfo(int _destination, long _distance, int _cnt)
    {
        this.destination = _destination;
        this.distance = _distance;
        this.cnt = _cnt;
    }
}