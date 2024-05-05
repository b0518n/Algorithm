StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
long n = long.Parse(Console.ReadLine());
sw.WriteLine(BinarySearch());
sw.Flush();
sw.Close();

long BinarySearch()
{
    long left = 0;
    long right = n;
    long middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (Math.Pow(middle, 2) >= n)
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    return left;
}