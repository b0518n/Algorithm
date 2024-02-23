int n = int.Parse(Console.ReadLine());
int result = 0;
for (int i = 0; i < 7; i++)
{
    if ((n & (1 << i)) == (1 << i))
    {
        result++;
    }
}

Console.WriteLine(result);