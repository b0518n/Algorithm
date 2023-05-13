int x = int.Parse(Console.ReadLine());
int y = int.Parse(Console.ReadLine());

if (x > 0)
{
    if (y > 0)
    {
        Console.WriteLine("1");
    }
    else
    {
        Console.WriteLine("4");
    }
}
else
{
    if (y > 0)
    {
        Console.WriteLine("2");
    }
    else
    {
        Console.WriteLine("3");
    }
}