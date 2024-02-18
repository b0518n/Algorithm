StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int m = int.Parse(sr.ReadLine());
string input = null;
string[] str = null;
int s = 0;
int t = 0 << 2;

for (int i = 0; i < m; i++)
{
    input = sr.ReadLine();
    if (input.Substring(0, 3) == "add") // add
    {
        str = input.Split(" ");
        s |= 1 << int.Parse(str[1]) - 1;
    }
    else if (input.Substring(0, 3) == "che") // check
    {
        str = input.Split(" ");
        t = s & 1 << int.Parse(str[1]) - 1;
        if (t == 0)
        {
            sw.WriteLine(0);
        }
        else
        {
            sw.WriteLine(1);
        }
    }
    else if (input.Substring(0, 3) == "rem") // remove
    {
        str = input.Split(" ");
        s &= ~(1 << int.Parse(str[1]) - 1);
    }
    else if (input.Substring(0, 3) == "tog") // toggle
    {
        str = input.Split(" ");
        t = s & 1 << int.Parse(str[1]) - 1;
        if (t == 0)
        {
            s |= 1 << int.Parse(str[1]) - 1;
        }
        else
        {
            s &= ~(1 << int.Parse(str[1]) - 1);
        }
    }
    else if (input.Substring(0, 3) == "all") // all
    {
        s = (1 << 21) - 1;
    }
    else if (input.Substring(0, 3) == "emp") // empty
    {
        s = 0;
    }
}

sw.Flush();
sw.Close();