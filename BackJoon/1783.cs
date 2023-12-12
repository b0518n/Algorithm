int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int result = 0;

if (n == 1)
{
    result = 1;
}
else if (n == 2)
{
    result = Math.Min(4, (((m - 1) / 2) + 1));
}
else
{
    if (m - 1 == 6)
    {
        result = 5;
    }
    else if (m - 1 > 6)
    {
        result = (m - 1) - 6 + 5;
    }
    else
    {
        result = Math.Min(4, 1 + m - 1);
    }
}

Console.WriteLine(result);