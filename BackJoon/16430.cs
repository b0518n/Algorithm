int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int value1 = input[1] - input[0];
int value2 = input[1];

Console.WriteLine($"{value1} {value2}");