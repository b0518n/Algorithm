int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int c = input[2];

Console.WriteLine((a + b) % c);
Console.WriteLine(((a % c) + (b % c)) % c);
Console.WriteLine((a * b) % c);
Console.WriteLine(((a % c) * (b % c)) % c);