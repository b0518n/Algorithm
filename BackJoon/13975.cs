StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
int k = 0;
int[] input = null;
MinHeap heap = null;
long value = 0;
long tValue = 0;

for (int i = 0; i < t; i++)
{
    k = int.Parse(sr.ReadLine());
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

    heap = new MinHeap();
    value = 0;
    tValue = 0;

    for (int j = 0; j < k; j++)
    {
        heap.Add(input[j]);
    }

    while (true)
    {
        if (heap.Length() == 1)
        {
            break;
        }

        tValue = 0;

        value += heap.Peek();
        tValue += heap.Peek();
        heap.Remove();

        value += heap.Peek();
        tValue += heap.Peek();
        heap.Remove();

        heap.Add(tValue);
    }

    sw.WriteLine(value);
}

sw.Flush();
sw.Close();

class MinHeap
{
    public long[] minHeap;
    private int length;

    public MinHeap()
    {
        minHeap = new long[1000000];
        length = 0;
    }

    public void Add(long value)
    {
        if (length == 1000000)
        {
            return;
        }

        minHeap[length] = value;
        length++;
        HeapifyUp(length - 1);
    }

    public void Remove()
    {
        Swap(0, length - 1);
        minHeap[length - 1] = 0;
        length--;
        HeapifyDown(0);

    }

    public void HeapifyDown(int index)
    {
        int leftChildIndex = 2 * index + 1;
        int rightChildIndex = 2 * index + 2;
        int MinestChildIndex = index;

        if (leftChildIndex <= length - 1 && minHeap[leftChildIndex] < minHeap[MinestChildIndex])
        {
            MinestChildIndex = leftChildIndex;
        }

        if (rightChildIndex <= length - 1 && minHeap[rightChildIndex] < minHeap[MinestChildIndex])
        {
            MinestChildIndex = rightChildIndex;
        }

        if (MinestChildIndex != index)
        {
            Swap(MinestChildIndex, index);
            HeapifyDown(MinestChildIndex);
        }

    }

    public void HeapifyUp(int index)
    {
        int parent = (index - 1) / 2;

        while (true)
        {
            if (index == 0)
            {
                return;
            }

            if (minHeap[index] < minHeap[parent])
            {
                Swap(index, parent);
                index = parent;
                parent = (index - 1) / 2;
            }
            else
            {
                return;
            }
        }
    }

    public void Swap(int index1, int index2)
    {
        long temp = minHeap[index1];
        minHeap[index1] = minHeap[index2];
        minHeap[index2] = temp;
    }

    public long Peek()
    {
        return minHeap[0];
    }

    public int Length()
    {
        return length;
    }
}