int n = 0;
int max = -1;
int index = -1;

for (int i = 1; i < 10; i++)
{
    n = int.Parse(Console.ReadLine());
    if (n > max)
    {
        max = n;
        index = i;
    }
}

Console.WriteLine(max);
Console.WriteLine(index);