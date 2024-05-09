StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int t = input[1];

int s = 0;
int i = 0;
int c = 0;

List<int> busSchedule = new List<int>();
int result = -1;

for (int j = 0; j < n; j++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    s = input[0];
    i = input[1];
    c = input[2];

    busSchedule.Clear();
    for (int k = s; k <= s + (i * (c - 1)); k += i)
    {
        busSchedule.Add(k);
    }

    BinarySearch();
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

void BinarySearch()
{
    int left = 0;
    int right = c - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (busSchedule[middle] < t)
        {
            left = middle + 1;
        }
        else
        {
            right = middle - 1;
        }
    }

    if (left > c - 1 || left < 0)
    {
        return;
    }
    else
    {
        if (result == -1)
        {
            result = Math.Abs(busSchedule[left] - t);
        }
        else
        {
            result = Math.Min(result, Math.Abs(busSchedule[left] - t));
        }
    }
}