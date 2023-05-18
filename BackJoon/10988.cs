string str = Console.ReadLine();
char[] origin = str.ToArray();
char[] reverse = str.Reverse().ToArray();
bool equal = true;

for (int i = 0; i < origin.Length; i++)
{
    if (origin[i] != reverse[i])
    {
        equal = false;
        break;
    }
}

if (equal == true)
{
    Console.WriteLine("1");
}
else
{
    Console.WriteLine("0");
}