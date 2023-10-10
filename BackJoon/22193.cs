int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
BigInteger a = BigInteger.Parse(Console.ReadLine());
BigInteger b = BigInteger.Parse(Console.ReadLine());

BigInteger result = a * b;
Console.WriteLine(result);