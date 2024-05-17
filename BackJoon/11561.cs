using System.Numerics;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(sr.ReadLine());
BigInteger n = 0;

for (int i = 0; i < t; i++)
{
    sw.WriteLine(BinarySearch(BigInteger.Parse(sr.ReadLine())));
}

sw.Flush();
sw.Close();

BigInteger BinarySearch(BigInteger value)
{
    BigInteger left = 0;
    BigInteger right = value;
    BigInteger middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (middle * (middle + 1) / 2 > value)
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    return left - 1;
}