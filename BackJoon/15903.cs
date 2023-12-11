int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
MinHeap heap = new MinHeap();
for (int i = 0; i < n; i++)
{
    heap.Push(arr[i]);
}

long value = 0;
while (m > 0)
{
    value = 0;
    value += heap.Pop();
    value += heap.Pop();

    heap.Push(value);
    heap.Push(value);

    m--;
}

long result = 0;

while (heap.Count > 0)
{
    result += heap.Pop();
}

Console.WriteLine(result);

class MinHeap
{
    private List<long> heap;

    public MinHeap()
    {
        heap = new List<long>();
    }

    public int Count { get { return heap.Count; } }

    public void Push(long value)
    {
        heap.Add(value);
        HeapifyUp(heap.Count - 1);
    }

    public long Pop()
    {
        if (heap.Count == 0)
        {
            return -1;
        }

        long root = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        if (heap.Count > 1)
        {
            HeapifyDown(0);
        }

        return root;
    }

    private void HeapifyUp(int childIndex)
    {
        int parentIndex = (childIndex - 1) / 2;

        while (childIndex > 0 && heap[childIndex].CompareTo(heap[parentIndex]) < 0)
        {
            Swap(childIndex, parentIndex);
            childIndex = parentIndex;
            parentIndex = (childIndex - 1) / 2;
        }
    }

    private void HeapifyDown(int parentIndex)
    {
        int leftChildIndex = 2 * parentIndex + 1;
        int rightChildIndex = 2 * parentIndex + 2;
        int smallestChildIndex = parentIndex;

        if (leftChildIndex <= heap.Count - 1 && heap[leftChildIndex].CompareTo(heap[smallestChildIndex]) < 0)
        {
            smallestChildIndex = leftChildIndex;
        }

        if (rightChildIndex <= heap.Count - 1 && heap[rightChildIndex].CompareTo(heap[smallestChildIndex]) < 0)
        {
            smallestChildIndex = rightChildIndex;
        }

        if (smallestChildIndex != parentIndex)
        {
            Swap(parentIndex, smallestChildIndex);
            HeapifyDown(smallestChildIndex);
        }
    }

    private void Swap(int index1, int index2)
    {
        long temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}