BigInteger[] input = Array.ConvertAll(Console.ReadLine().Split(), BigInteger.Parse);
BigInteger n = input[0];
BigInteger m = input[1];

BigInteger mok = n / m;
BigInteger nmg = n % m;

Console.WriteLine(mok);
Console.WriteLine(nmg);