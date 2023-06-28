StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int x = 0;
List<int> heap = new List<int>();

for (int i = 0; i < n; i++)
{
    x = int.Parse(sr.ReadLine());

    if (x == 0)
    {
        if (heap.Count == 0)
        {
            sw.WriteLine(0);
        }
        else
        {
            int tmp = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            sw.WriteLine(tmp);
        }
    }
    else
    {
        if (heap.Count == 0)
        {
            heap.Add(x);
        }
        else
        {
            heap.Insert(BinaraySearch(heap, 0, heap.Count - 1, x), x);
        }
    }
}

sw.Flush();
sw.Close();
sr.Close();

int BinaraySearch(List<int> heap, int start, int end, int value)
{
    int mid = 0;

    while (start <= end)
    {
        mid = (start + end) / 2;
        if (Math.Abs(heap[mid]) < Math.Abs(value))
        {
            end = mid - 1;
        }
        else if (Math.Abs(heap[mid]) > Math.Abs(value))
        {
            start = mid + 1;
        }
        else
        {
            if (heap[mid] > value)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
    }

    return start;
}