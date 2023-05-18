int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < 4 - i; j++)
    {
        Console.Write(" ");
    }

    for (int j = 0; j < (2 * i) + 1; j++)
    {
        Console.Write("*");
    }

    Console.WriteLine();
}

for (int i = n - 2; i >= 0; i--)
{
    for (int j = 0; j < 4 - i; j++)
    {
        Console.Write(" ");
    }

    for (int j = 0; j < (2 * i) + 1; j++)
    {
        Console.Write("*");
    }

    if (i != 0)
    {
        Console.WriteLine();
    }
}