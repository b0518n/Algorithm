﻿long[] input = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
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

if ((top1 + top2) % GCD(max,min) == 0)
{
    
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