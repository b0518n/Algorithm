StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int result = GetLargestIncreaseSequenceLength(arr);
sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();

int GetLargestIncreaseSequenceLength(int[] sequence)
{
    List<int> list = new List<int>();
    list.Add(sequence[0]);

    for (int i = 1; i < sequence.Length; i++)
    {
        if (list[list.Count - 1] < sequence[i])
        {
            list.Add(sequence[i]);
        }
        else
        {
            list[BinarySearch(0, list.Count - 1, sequence[i], list)] = sequence[i]; 
        }
    }

    return list.Count;
}

int BinarySearch(int start, int end, int value, List<int> list)
{
    int mid = 0;

    while (start <= end)
    {
        mid = (start + end) / 2;

        if (list[mid] < value)
        {
            start = mid + 1;
        }
        else
        {
            end = mid - 1;
        }
    }

    return start;
}