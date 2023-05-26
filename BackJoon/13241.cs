// 유클리드 호제법

long GCD(long x, long y)
{
    if (y == 0)
    {
        return x;
    }

    return GCD(y, x % y);
}

long LCM(long x, long y)
{
    return (x * y) / GCD(x, y);
}

long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
long a = 0;
long b = 0;
if (input[0] >= input[1])
{
    a = input[0];
    b = input[1];
}
else
{
    a = input[1];
    b = input[0];
}

long result = LCM(a, b);
Console.WriteLine(result);