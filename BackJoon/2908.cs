string[] str = Console.ReadLine().Split();
char[] a = str[0].Reverse().ToArray();
char[] b = str[1].Reverse().ToArray();

for (int i = 0; i < 3; i++)
{
    if (a[i] > b[i])
    {
        Console.WriteLine(a[0].ToString() + a[1].ToString() + a[2].ToString());
        break;
    }
    else if (a[i] < b[i])
    {
        Console.WriteLine(b[0].ToString() + b[1].ToString() + b[2].ToString());
        break;
    }
}