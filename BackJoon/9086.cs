using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
string str = null;
for (int i = 0; i < t; i++)
{
    str = Console.ReadLine();
    if (str.Length == 1)
    {
        sb.AppendLine((str[0].ToString() + str[0].ToString()));
    }
    else
    {
        sb.AppendLine(str[0].ToString() + str[str.Length - 1].ToString());
    }
}

Console.WriteLine(sb.ToString());