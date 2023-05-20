int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int v = input[2];
int result = 0;
int mok = 0;
int nmg = 0;

if (v == a)
{
    result = 1;
}
else
{
    mok = (v - a) / (a - b);
    nmg = (v - a) % (a - b);
    if (nmg == 0)
    {
        result = mok + 1;
    }
    else
    {
        result = mok + 1 + 1;
    }
}

Console.WriteLine(result);