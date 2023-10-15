int t = int.Parse(Console.ReadLine());
int[] times = new int[3] { 300, 60, 10 };
int[] count = new int[3] { 0, 0, 0 };

int mok = 0;
int nmg = 0;

for (int i = 0; i < 3; i++)
{
    mok = 0;
    nmg = 0;

    mok = t / times[i];
    nmg = t % times[i];

    count[i] = mok;
    t = nmg;
}

if (t == 0)
{
    Console.WriteLine(string.Join(" ", count));
}
else
{
    Console.WriteLine(-1);
}