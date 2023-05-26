long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
long a = input[0];
long b = input[1];

input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
long c = input[0];
long d = input[1];

long min = b <= d ? b : d;
long max = b >= d ? b : d;

long bottom = LCM(max, min);
long top1 = (bottom / b) * a;
long top2 = (bottom / d) * c;
long top = top1 + top2;

long gcd = 0;
if (top1 + top2 > bottom)
{
    gcd = GCD(top1 + top2, bottom);
}
else
{
    gcd = GCD(top1 + top2, bottom);
}

if (gcd == 1)
{
    Console.WriteLine($"{top1 + top2} {bottom}");
}
else
{
    Console.WriteLine($"{(top1 + top2) / gcd} {bottom / gcd}");
}

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