long s = long.Parse(Console.ReadLine());
long start = 1;
long end = uint.MaxValue;
long mid = 0;
long result = 0;

while (start <= end)
{
    mid = (start + end) / 2;
    result = mid * (mid + 1) / 2;
    if (result > s)
    {
        end = mid - 1;
    }
    else
    {
        start = mid + 1;
    }
}

Console.WriteLine(end);