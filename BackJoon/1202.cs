int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int m = 0;
int v = 0;

List<int[]> jewels = new List<int[]>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    m = input[0];
    v = input[1];

    jewels.Add(new int[2] { m, v });
}

jewels.Sort((x, y) =>
{
    int result = x[0].CompareTo(y[0]);

    if (result == 0)
    {
        result = y[1].CompareTo(x[1]);
    }

    return result;
});

Queue<int[]> queue = new Queue<int[]>();
for (int i = 0; i < jewels.Count; i++)
{
    queue.Enqueue(jewels[i]);
}

int c = 0;
List<int> list = new List<int>();

for (int i = 0; i < k; i++)
{
    c = int.Parse(Console.ReadLine());
    list.Add(c);
}

list.Sort();
Queue<int> bags = new Queue<int>();
long result = 0;

for (int i = 0; i < list.Count; i++)
{
    bags.Enqueue(list[i]);
}

MaxHeap maxHeap = new MaxHeap(1000000);

for (int i = 0; i < k; i++)
{
    while (queue.Count > 0 && list[i] >= queue.First()[0])
    {
        maxHeap.Insert(queue.First()[1]);
        queue.Dequeue();
    }

    if (maxHeap.size > 0)
    {
        result += maxHeap.ExtractMax();
    }

    if (maxHeap.size <= 0 && jewels.Count <= 0)
    {
        break;
    }
}

Console.WriteLine(result);

public class MaxHeap
{
    public int[] heap;
    public int size;
    public int capacity;

    public MaxHeap(int capacity)
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
            // 힙이 가득찬 경우
            return;
        }

        size++;
        int i = size - 1;
        heap[i] = value;

        // 최소 힙
        while (i != 0 && heap[Parent(i)] < heap[i])
        {
            int temp = heap[i];
            heap[i] = heap[Parent(i)];
            heap[Parent(i)] = temp;

            i = Parent(i);
        }
    }

    public int ExtractMax()
    {
        if (size <= 0)
        {
            // 힙이 비어 있을 때
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
        MaxHeapify(0);

        return root;
    }

    private void MaxHeapify(int i)
    {
        int left = LeftChild(i);
        int right = RightChild(i);
        int biggest = i;

        if (left < size && heap[left] > heap[i])
        {
            biggest = left;
        }

        if (right < size && heap[right] > heap[biggest])
        {
            biggest = right;
        }

        if (biggest != i)
        {
            int swap = heap[i];
            heap[i] = heap[biggest];
            heap[biggest] = swap;
            MaxHeapify(biggest);
        }
    }

    public void DeleteAtIndex(int index)
    {
        if (index >= size || index < 0)
        {
            return;
        }

        heap[index] = heap[size - 1];
        size--;

        if (index < size)
        {
            if (index > 0 && heap[index] > heap[Parent(index)])
            {
                while (index > 0 && heap[Parent(index)] < heap[index])
                {
                    int temp = heap[index];
                    heap[index] = heap[Parent(index)];
                    heap[Parent(index)] = temp;
                    index = Parent(index);
                }
            }
            else
            {
                MaxHeapify(index);
            }
        }
    }
}