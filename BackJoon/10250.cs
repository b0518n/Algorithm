int t = int.Parse(Console.ReadLine());
for (int i = 0; i < t; i++)
{
    string[] input = Console.ReadLine().Split(" ");
    int h = int.Parse(input[0]);
    int w = int.Parse(input[1]);
    int n = int.Parse(input[2]);

    int mok = n / h;
    int nmg = n % h;

    if (mok < 9)
    {
        if (nmg == 0)
        {
            Console.WriteLine(h.ToString() + "0" + mok.ToString());
        }
        else
        {
            Console.WriteLine(nmg.ToString() + "0" + (mok + 1).ToString());
        }
    }
    else if (mok == 9)
    {
        if (nmg == 0)
        {
            Console.WriteLine(h.ToString() + "0" + mok.ToString());
        }
        else
        {
            Console.WriteLine(nmg.ToString() + (mok + 1).ToString());
        }
    }
    else if (mok > 9)
    {
        if (nmg == 0)
        {
            Console.WriteLine(h.ToString() + mok.ToString());
        }
        else
        {
            Console.WriteLine(nmg.ToString() + (mok + 1).ToString());
        }
    }

}

