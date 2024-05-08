StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[] arr = null;

if (n == 1)
{
    arr = new int[1] { int.Parse(Console.ReadLine()) };
}
else
{
    arr = new int[n];
    for (int i = 0; i < n; i++)
    {
        arr[i] = int.Parse(Console.ReadLine());
    }
}

Array.Sort(arr);
for (int i = 0; i < m; i++)
{
    BinarySearch(int.Parse(Console.ReadLine()));
}

sw.Flush();
sw.Close();

void BinarySearch(int value)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    int result = -1;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (arr[middle] >= value)
        {
            right = middle - 1;
            if (arr[middle] == value)
            {
                if (result == -1)
                {
                    result = middle;
                }
                else
                {
                    result = Math.Min(result, middle);
                }
            }
        }
        else
        {
            left = middle + 1;
        }
    }

    sw.WriteLine(result);
}