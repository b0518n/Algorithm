int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int h = input[0];
int m = input[1];

if (m >= 45)
{
    m -= 45;
}
else
{
    m = m + (60 - 45);
    if (h >= 1)
    {
        h -= 1;
    }
    else
    {
        h = 23;
    }
}

Console.WriteLine($"{h} {m}");