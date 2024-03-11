int[] input = null;
int p = 0;
int l = 0;
int v = 0;

int result = 0;
int mok = 0;
int nmg = 0;
int i = 1;

while (true)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    l = input[0];
    p = input[1];
    v = input[2];

    if (l == 0 && p == 0 && v == 0)
    {
        break;
    }

    mok = v / p;
    nmg = v % p;

    result += l * mok;
    if (nmg >= l)
    {
        result += l;
    }
    else
    {
        result += nmg;
    }

    Console.WriteLine($"Case {i}: {result}");
    i++;
    result = 0;
}