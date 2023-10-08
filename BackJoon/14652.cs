int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];

int number = 0;

int y = 0;
int x = 0;

while (true)
{
    if (number == k)
    {
        break;
    }

    if (x == m - 1)
    {
        y++;
        x = 0;
    }
    else
    {
        x++;
    }

    number++;
}

Console.WriteLine($"{y} {x}");