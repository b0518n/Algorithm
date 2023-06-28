StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
List<long> heap = new List<long>();
long value = 0;

for (int i = 0; i < n; i++)
{
    value = long.Parse(sr.ReadLine());
    if (value == 0)
    {
        if (heap.Count == 0)
        {
            sw.WriteLine(0);
        }
        else
        {
            long tmp = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            sw.WriteLine(tmp);
        }
    }
    else
    {
        if (heap.Count == 0 || value >= heap[heap.Count - 1])
        {
            heap.Add(value);
        }
        else
        {
            heap.Insert(BinarySearch(heap, value, 0, heap.Count - 1), value);
        }
    }
}

sw.Flush();
sw.Close();
sr.Close();

int BinarySearch(List<long> heap, long value, int start, int end)
{
    int mid = 0;

    while (start <= end)
    {
        mid = (start + end) / 2;
        if (heap[mid] >= value)
        {
            end = mid - 1;
        }
        else
        {
            start = mid + 1;
        }
    }

    return start;
}