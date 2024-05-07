using System.Numerics;

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
BigInteger n = BigInteger.Parse(Console.ReadLine());
sw.WriteLine(BinarySearch());
sw.Flush();
sw.Close();

BigInteger BinarySearch()
{
    BigInteger left = 0;
    BigInteger right = n;
    BigInteger middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (BigInteger.Pow(middle, 2) >= n)
        {
            right = middle - 1;
        }
        else if (BigInteger.Pow(middle, 2) < n)
        {
            left = middle + 1;
        }
    }

    return left;
}