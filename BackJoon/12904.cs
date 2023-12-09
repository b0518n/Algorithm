string s = Console.ReadLine();
string t = Console.ReadLine();

while (t.Length > s.Length)
{
    if (t[t.Length - 1] == 'A')
    {
        t = t.Substring(0, t.Length - 1);
    }
    else
    {
        t = t.Substring(0, t.Length - 1);
        t = new string(t.Reverse().ToArray());
    }
}

if (s == t)
{
    Console.WriteLine(1);
}
else
{
    Console.WriteLine(0);
}