StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int s = 0;
int d = 0;
int[] distArr = new int[n + 1];
List<Dictionary<int, int>> edgeList = new List<Dictionary<int, int>>();
int[] visited = new int[n + 1];

InitEdge_Fun();
InputEdge_Fun();
InputStartAndDestPos_Fun();
InitArr_Fun();
Dijkstra();

sw.WriteLine(distArr[d]);
sw.Flush();
sw.Close();

void InitArr_Fun()
{
    for (int i = 1; i < n + 1; i++)
    {
        if (i == s)
        {
            continue;
        }

        distArr[i] = int.MaxValue;
    }
}
void InitEdge_Fun()
{
    for (int i = 0; i < n + 1; i++)
    {
        edgeList.Add(new Dictionary<int, int>());
    }
}
void InputEdge_Fun()
{
    for (int i = 0; i < m; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        edgeList[input[0]].Add(input[1], input[2]);
        edgeList[input[1]].Add(input[0], input[2]);
    }
}
void InputStartAndDestPos_Fun()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    s = input[0];
    d = input[1];
}
void Dijkstra()
{
    MinHeap pq = new MinHeap();
    pq.Push(s, 0);

    PosInfo temp;

    while (pq.count > 0)
    {
        temp = pq.Peek();
        pq.Pop();
        if (visited[temp.destination] == 1)
            continue;

        visited[temp.destination] = 1;
        foreach (int dest in edgeList[temp.destination].Keys)
        {
            if (visited[dest] == 1)
            {
                continue;
            }

            if (distArr[dest] == int.MaxValue)
            {
                distArr[dest] = temp.distance + edgeList[temp.destination][dest];
                pq.Push(dest, temp.distance + edgeList[temp.destination][dest]);
            }
            else
            {
                if (distArr[dest] > temp.distance + edgeList[temp.destination][dest])
                {
                    distArr[dest] = temp.distance + edgeList[temp.destination][dest];
                    pq.Push(dest, temp.distance + edgeList[temp.destination][dest]);
                }
            }
        }
    }
}

class MinHeap
{
    public List<PosInfo> container;
    public int count;

    public MinHeap()
    {
        this.container = new List<PosInfo>();
        this.count = 0;
    }

    public void Push(int _destination, int _distance)
    {
        this.container.Add(new PosInfo(_destination, _distance));
        count++;
        HeapifyUp(count - 1);
    }

    public PosInfo Peek()
    {
        return container[0];
    }

    public void Pop()
    {
        Swap(0, count - 1);
        this.container.RemoveAt(this.count - 1);
        count--;
        HeapifyDown(0);
    }

    public void Swap(int _index1, int _index2)
    {
        PosInfo temp = this.container[_index1];
        this.container[_index1] = this.container[_index2];
        this.container[_index2] = temp;
    }

    public void HeapifyUp(int _index)
    {
        int parentIndex = 0;

        while (true)
        {
            parentIndex = (_index - 1) / 2;
            if (parentIndex == _index)
                break;

            if (parentIndex >= 0 && this.container[parentIndex].distance > this.container[_index].distance)
            {
                Swap(parentIndex, _index);
                _index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    public void HeapifyDown(int _index)
    {
        int leftChildIndex = 0;
        int rightChildIndex = 0;
        int minIndex = 0;

        while (true)
        {
            leftChildIndex = (2 * _index) + 1;
            rightChildIndex = (2 * _index) + 2;
            minIndex = _index;

            if (leftChildIndex < this.count && this.container[leftChildIndex].distance < this.container[minIndex].distance)
            {
                minIndex = leftChildIndex;
            }

            if (rightChildIndex < this.count && this.container[rightChildIndex].distance < this.container[minIndex].distance)
            {
                minIndex = rightChildIndex;
            }

            if (minIndex == _index)
                break;

            Swap(minIndex, _index);
            _index = minIndex;

            if (_index < 0 || _index >= this.container.Count)
            {
                break;
            }
        }
    }

}
class PosInfo
{
    public int destination;
    public int distance;

    public PosInfo(int _destination, int _distance)
    {
        this.destination = _destination;
        this.distance = _distance;
    }
}