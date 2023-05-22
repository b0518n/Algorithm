int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a1 = input[0]; // f(n) 기울기
int a0 = input[1];
int c = int.Parse(Console.ReadLine()); // c * g(n) 기울기
int n0 = int.Parse(Console.ReadLine());

float value = (float)a0 / (c - a1); // 교점

if (a1 > 0)
{
    if (a1 > c)
    {
        Console.WriteLine(0);
    }
    else if (a1 < c)
    {
        if (n0 >= value)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
    else if (a1 == c)
    {
        if (a0 <= 0)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
else if (a1 < 0)
{
    if (n0 >= value)
    {
        Console.WriteLine(1);
    }
    else
    {
        Console.WriteLine(0);
    }
}
else if (a1 == 0)
{
    if (n0 >= value)
    {
        Console.WriteLine(1);
    }
    else
    {
        Console.WriteLine(0);
    }
}