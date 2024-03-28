StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

MinHeap minHeap = new MinHeap();
List<MeetingInfo> meetings = new List<MeetingInfo>();
int result = 0;

int n = 0;
int[] input = null;

Input();
meetings.Sort((x, y) =>
{
    int compare = x.start.CompareTo(y.start);

    if (compare == 0)
    {
        compare = x.end.CompareTo(y.end);
    }

    return compare;
});

for (int i = 0; i < n; i++)
{
    if (minHeap.length == 0)
    {
        minHeap.Add(meetings[i].end);
        result++;
    }
    else
    {
        if (minHeap.Peek() <= meetings[i].start)
        {
            minHeap.Pop();
            minHeap.Add(meetings[i].end);
        }
        else
        {
            minHeap.Add(meetings[i].end);
            result++;
        }
    }
}

Print();

void Input()
{
    n = int.Parse(sr.ReadLine());

    for (int i = 0; i < n; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        meetings.Add(new MeetingInfo(input[0], input[1]));
    }
}

void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}

class MeetingInfo
{
    public int start;
    public int end;

    public MeetingInfo(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}

class MinHeap
{
    public List<int> container;
    public int length;

    public MinHeap()
    {
        this.container = new List<int>();
        this.length = 0;
    }

    public void Add(int value)
    {
        this.container.Add(value);
        this.length++;
        HeapifyUp(this.length - 1);
    }

    public void Pop()
    {
        Swap(0, this.length - 1);
        this.container.RemoveAt(this.length - 1);
        this.length--;
        HeapifyDown(0);
    }

    public int Peek()
    {
        if (length == 0)
        {
            return -1;
        }

        return this.container[0];
    }

    public void HeapifyUp(int index)
    {
        int parentIndex = (index - 1) / 2;

        if (parentIndex != index && this.container[parentIndex] > this.container[index])
        {
            Swap(parentIndex, index);
            HeapifyUp(parentIndex);
        }
    }

    public void HeapifyDown(int parentIndex)
    {
        int leftChildIndex = 2 * parentIndex + 1;
        int rightChildIndex = 2 * parentIndex + 2;
        int MinestIndex = parentIndex;

        if (leftChildIndex <= this.length - 1 && container[leftChildIndex] < container[MinestIndex])
        {
            MinestIndex = leftChildIndex;
        }

        if (rightChildIndex <= this.length - 1 && container[rightChildIndex] < container[MinestIndex])
        {
            MinestIndex = rightChildIndex;
        }

        if (MinestIndex != parentIndex)
        {
            Swap(MinestIndex, parentIndex);
            HeapifyDown(MinestIndex);
        }
    }

    private void Swap(int index1, int index2)
    {
        int tValue = container[index1];
        container[index1] = container[index2];
        container[index2] = tValue;
    }
}