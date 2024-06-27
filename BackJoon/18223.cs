StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int v = input[0];
int e = input[1];
int p = input[2];

int[] distanceArr = new int[v + 1];
List<Dictionary<int, int>> edgeList = new List<Dictionary<int, int>>();
List<List<int>> beforeVetexList = new List<List<int>>();

InitArr_Fun();
InitEdgeList_Fun();
InputEdge_Fun();
Dijkstra_Fun();
DFS();
sw.Flush();
sw.Close();

void InitArr_Fun()
{
    for (int i = 2; i < v + 1; i++)
    {
        distanceArr[i] = int.MaxValue;
    }
}
void InitEdgeList_Fun()
{
    for (int i = 0; i < v + 1; i++)
    {
        edgeList.Add(new Dictionary<int, int>());
        beforeVetexList.Add(new List<int>());
    }
}
void InputEdge_Fun()
{
    for (int i = 0; i < e; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        edgeList[input[0]].Add(input[1], input[2]);
        edgeList[input[1]].Add(input[0], input[2]);
    }
}
void Dijkstra_Fun()
{
    MinHeap pq = new MinHeap();
    pq.Push(1, 0);

    PosInfo temp = null;

    while (pq.count > 0)
    {
        temp = pq.Peek();
        pq.Pop();


        foreach (int dest in edgeList[temp.destination].Keys)
        {
            if (distanceArr[dest] == int.MaxValue)
            {
                distanceArr[dest] = temp.distance + edgeList[temp.destination][dest];
                beforeVetexList[dest].Add(temp.destination);
                pq.Push(dest, distanceArr[dest]);
            }
            else
            {
                if (distanceArr[dest] > temp.distance + edgeList[temp.destination][dest])
                {
                    distanceArr[dest] = Math.Min(distanceArr[dest], temp.distance + edgeList[temp.destination][dest]);
                    beforeVetexList[dest].Clear();
                    beforeVetexList[dest].Add(temp.destination);
                    pq.Push(dest, distanceArr[dest]);
                }
                else if (distanceArr[dest] == temp.distance + edgeList[temp.destination][dest])
                {
                    distanceArr[dest] = Math.Min(distanceArr[dest], temp.distance + edgeList[temp.destination][dest]);
                    beforeVetexList[dest].Add(temp.destination);
                    pq.Push(dest, distanceArr[dest]);
                }
            }
        }
    }
}
void DFS()
{
    Stack<int> stack = new Stack<int>();
    stack.Push(v);
    int temp = 0;
    bool shouldHelp = false;

    while (stack.Count > 0)
    {
        temp = stack.Pop();

        foreach (int i in beforeVetexList[temp])
        {
            if (i == p)
            {
                shouldHelp = true;
                break;
            }
            else
            {
                stack.Push(i);
            }
        }
    }

    if (shouldHelp)
    {
        sw.WriteLine("SAVE HIM");
    }
    else
    {
        sw.WriteLine("GOOD BYE");
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