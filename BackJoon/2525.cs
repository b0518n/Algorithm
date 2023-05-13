int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int c = int.Parse(Console.ReadLine());

int d = b + c;
if (d >= 60)
{
    int mok = d / 60;
    int nmg = d % 60;
    if (a + mok >= 24)
    {
        Console.WriteLine($"{a + mok - 24} {nmg}");
    }
    else
    {
        Console.WriteLine($"{a + mok} {nmg}");
    }
}
else
{
    Console.WriteLine($"{a} {d}");
}