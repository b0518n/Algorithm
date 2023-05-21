int n = int.Parse(Console.ReadLine());
long result = 4;
if (n > 1)
{
    for (int i = 1; i < n; i++)
    {
        result += 4;
    }
}

Console.WriteLine(result);