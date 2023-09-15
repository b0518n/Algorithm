long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
long n = input[0];
long m = input[1];

Console.WriteLine(Math.Abs(n - m));