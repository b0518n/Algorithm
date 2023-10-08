int l = int.Parse(Console.ReadLine());
int mok = l / 5;
int nmg = l % 5;

if (nmg == 0)
{
    Console.WriteLine(mok);
}
else
{
    Console.WriteLine(mok + 1);
}