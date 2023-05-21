int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int x = input[0];
int y = input[1];
int w = input[2];
int h = input[3];

int min = 1000;
if (min > w - x)
{
    min = w - x;
}

if (min > x - 0)
{
    min = x - 0;
}

if (min > h - y)
{
    min = h - y;
}

if (min > y - 0)
{
    min = y - 0;
}

Console.WriteLine(min);