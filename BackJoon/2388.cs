BigInteger a = BigInteger.Parse(Console.ReadLine());
BigInteger b = BigInteger.Parse(Console.ReadLine());

BigInteger sum = a + b;
BigInteger subtraction = a - b;
BigInteger multiplication = a * b;

StringBuilder sb = new StringBuilder();
sb.AppendLine(sum.ToString());
sb.AppendLine(subtraction.ToString());
sb.AppendLine(multiplication.ToString());

Console.WriteLine(sb.ToString());