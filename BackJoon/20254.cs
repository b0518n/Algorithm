int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int result = (56 * input[0]) + (24 * input[1]) + (14 * input[2]) + (6 * input[3]);
Console.WriteLine(result);