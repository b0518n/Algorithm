int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int e = input[0];
int s = input[1];
int m = input[2];

int year = 1;

int x = 1;
int y = 1;
int z = 1;

if (e != x)
{
    x += (e - 1);
    y += (e - 1);
    z += (e - 1);

    year += (e - 1);
}

while (true)
{
    if (x == e && y == s && z == m)
    {
        break;
    }

    y += 15;
    y = (y % 28 == 0 ? 28 : y % 28);
    z += 15;
    z = (z % 19 == 0 ? 19 : z % 19);

    year += 15;
}

Console.WriteLine(year);