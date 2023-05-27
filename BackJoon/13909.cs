int n = int.Parse(Console.ReadLine());
int i = 1;
while (true)
{
    if (i * i > n)
    {
        Console.WriteLine(i - 1);
        break;
    }
    else
    {
        i++;
    }
}