int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int[] temp = new int[n];

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int count = 0;
int result = 0;
List<int> list = new List<int>();

MergeSort(input, 0, input.Length - 1);
if (list.Count < k)
{
    Console.WriteLine(-1);
}
else
{
    Console.WriteLine(list[k - 1]);
}

void MergeSort(int[] arr, int start, int end)
{
    if (start >= end)
    {
        return;
    }

    int mid = (start + end) / 2;

    MergeSort(arr, start, mid);
    MergeSort(arr, mid + 1, end);
    Merge(arr, start, end, mid);
}

void Merge(int[] arr, int start, int end, int mid)
{
    for (int i = start; i <= end; i++)
    {
        temp[i] = arr[i];
    }

    int index1 = start;
    int index2 = mid + 1;
    int index = start;

    while (index1 <= mid && index2 <= end)
    {
        if (temp[index1] <= temp[index2])
        {
            arr[index] = temp[index1];
            list.Add(arr[index]);
            index1++;
        }
        else
        {
            arr[index] = temp[index2];
            list.Add(arr[index]);
            index2++;
        }

        index++;
    }

    while (index1 <= mid)
    {
        arr[index] = temp[index1];
        list.Add(arr[index]);
        index++;
        index1++;
    }

    while (index2 <= end)
    {
        arr[index] = temp[index2];
        list.Add(arr[index]);
        index++;
        index2++;
    }
}