// 풀이
//
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int v = input[2];

int result = ((v - a) / (a - b)) + 1;
Console.WriteLine(result);