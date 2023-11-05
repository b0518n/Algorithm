int n = int.Parse(Console.ReadLine());
List<int> rooms = new List<int>();
int[] input = null;
int s = 0;
int t = 0;

List<int[]> list = new List<int[]>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    s = input[0];
    t = input[1];

    list.Add(new int[2] { s, t });
}

list.Sort((x, y) =>
{
    int result = x[0].CompareTo(y[0]);
    if (result == 0)
    {
        result = x[1].CompareTo(y[1]);
    }

    return result;
});

MinHeap minHeap = new MinHeap(n);
int result = 0;

for (int i = 0; i < list.Count; i++)
{
    if (minHeap.Size == 0)
    {
        minHeap.Insert(list[i][1]);
        result = Math.Max(result, minHeap.Size);
    }
    else
    {
        if (minHeap.PrintMin() <= list[i][0])
        {
            minHeap.ExtractMin();
            minHeap.Insert(list[i][1]);
        }
        else
        {
            minHeap.Insert(list[i][1]);
            result = Math.Max(result, minHeap.Size);
        }
    }
}

Console.WriteLine(result);
    }

    class MinHeap
{
    private int[] heap;
    private int size;
    private int capacity;

    public int Size { get { return size; } }

    public MinHeap(int capacity)
    {
        this.capacity = capacity;
        heap = new int[capacity];
        size = 0;
    }

    private int Parent(int i) => (i - 1) / 2;
    private int LeftChild(int i) => 2 * i + 1;
    private int RightChild(int i) => 2 * i + 2;

    public void Insert(int value)
    {
        if (size == capacity)
        {
            return;
        }

        size++;
        int i = size - 1;
        heap[i] = value;

        while (i != 0 && heap[Parent(i)] > heap[i])
        {
            int temp = heap[i];
            heap[i] = heap[Parent(i)];
            heap[Parent(i)] = temp;

            i = Parent(i);
        }

    }

    public int ExtractMin()
    {
        if (size <= 0)
        {
            return -1;
        }

        if (size == 1)
        {
            size--;
            return heap[0];
        }

        int root = heap[0];
        heap[0] = heap[size - 1];
        size--;

        MinHeapify(0);

        return root;
    }

    private void MinHeapify(int i)
    {
        int left = LeftChild(i);
        int right = RightChild(i);
        int smallest = i;

        if (left < size && heap[left] < heap[smallest])
        {
            smallest = left;
        }

        if (right < size && heap[right] < heap[smallest])
        {
            smallest = right;
        }

        if (smallest != i)
        {
            int swap = heap[i];
            heap[i] = heap[smallest];
            heap[smallest] = swap;

            MinHeapify(smallest);
        }
    }

    public int PrintMin()
    {
        if (size <= 0)
        {
            return -1;
        }

        return heap[0];
    }