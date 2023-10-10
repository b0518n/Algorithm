int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int result = 0;
for (int i = 0; i < input.Length; i++)
{
    result += (input[i] * 5);
}

Console.WriteLine(result);
