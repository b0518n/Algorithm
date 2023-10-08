int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];

Console.WriteLine(Solve(a, b));

BigInteger Solve(int a, int b)
{
    int value1 = a + b;
    int value2 = a - b;

    return (BigInteger)value1 * value2;
}