int n = int.Parse(Console.ReadLine());
int[] input = null;
List<int[]> list = new List<int[]>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list.Add(new int[2] { input[0], input[1] });
}

list.Sort((x, y) =>
{
    int compare = x[0].CompareTo(y[0]);

    if (compare == 0)
    {
        compare = x[1].CompareTo(y[1]) * -1;
    }
    return compare;
});
MinHeap minHeap = new MinHeap();
int result = 0;

for (int i = 0; i < n; i++)
{
    if (minHeap.count < list[i][0])
    {
        result += list[i][1];
        minHeap.Push(list[i][1]);
    }
    else
    {
        if (minHeap.Peek() < list[i][1])
        {
            result -= minHeap.Peek();
            result += list[i][1];
            minHeap.Pop();
            minHeap.Push(list[i][1]);
        }
    }
}

Console.WriteLine(result);

class MinHeap
{
    private List<int> heap;
    public int count { get; private set; }

    public MinHeap()
    {
        heap = new List<int>();
        count = 0;
    }

    public void Push(int data)
    {
        heap.Add(data);
        count++;

        if (count >= 2)
        {
            HeapifyUp(count - 1);
        }
    }

    public int Peek()
    {
        int result = -1;
        if (heap.Count != -1)
        {
            result = heap[0];
        }

        return result;
    }

    public int Pop()
    {
        if (count == 0)
        {
            return -1;
        }

        int value = heap[0];
        Swap(0, count - 1);
        heap.RemoveAt(count - 1);
        count--;
        HeapifyDown(0);

        return value;
    }

    private void HeapifyUp(int childIndex)
    {
        int parentIndex = (childIndex - 1) / 2;

        while (childIndex > 0 && heap[parentIndex] > heap[childIndex])
        {
            Swap(parentIndex, childIndex);
            childIndex = parentIndex;
            parentIndex = (parentIndex - 1) / 2;
        }
    }

    private void HeapifyDown(int parentIndex)
    {
        int leftChildIndex = parentIndex * 2 + 1;
        int rightChildIndex = parentIndex * 2 + 2;
        int smallestIndex = parentIndex;

        if (leftChildIndex <= count - 1 && heap[leftChildIndex] < heap[smallestIndex])
        {
            smallestIndex = leftChildIndex;
        }

        if (rightChildIndex <= count - 1 && heap[rightChildIndex] < heap[smallestIndex])
        {
            smallestIndex = rightChildIndex;
        }

        if (parentIndex != smallestIndex)
        {
            Swap(smallestIndex, parentIndex);
            HeapifyDown(smallestIndex);
        }
    }

    private void Swap(int index1, int index2)
    {
        int temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}