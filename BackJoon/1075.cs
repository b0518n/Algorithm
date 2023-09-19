int n = int.Parse(Console.ReadLine());
int f = int.Parse(Console.ReadLine());

int mok = n / f;
int nmg = n % f;

int value = n % 100;

value -= nmg;
if (value < 0)
{
    value += nmg;
    value += f - nmg;
}

mok = value / f;
value -= f * mok;

if (value < 10)
{
    Console.WriteLine("0" + value.ToString());
}
else
{
    Console.WriteLine(value.ToString());
}