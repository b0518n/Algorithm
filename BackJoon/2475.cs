int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int value = 0;

for (int i = 0; i < 5; i++)
{
    value += (int)Math.Pow(input[i], 2);
}

int result = value % 10;
Console.WriteLine(result);