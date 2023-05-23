int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(input);
Console.WriteLine(input[input.Length - k]);