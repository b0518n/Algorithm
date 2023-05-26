BigInteger gcd(BigInteger x, BigInteger y)
{
    BigInteger first = 0;
    BigInteger second = 0;
    if (x > y)
    {
        first = x;
        second = y;
    }
    else
    {
        first = y;
        second = x;
    }

    if (second == 1)
    {
        return 1;
    }

    if (first % second != 0)
    {
        return gcd(second, first % second);
    }
    else
    {
        return first / second;
    }
}

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
BigInteger[] input = Array.ConvertAll(Console.ReadLine().Split(), BigInteger.Parse);
BigInteger a = input[0];
BigInteger b = input[1];

BigInteger result = gcd(a, b);

sw.WriteLine(result * (a / result) * (b / result));
sw.Close();