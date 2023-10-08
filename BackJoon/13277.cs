BigInteger[] input = Array.ConvertAll(Console.ReadLine().Split(), BigInteger.Parse);
StringBuilder sb = new StringBuilder();
sb.AppendLine((input[0] * input[1]).ToString());
Console.WriteLine(sb.ToString());