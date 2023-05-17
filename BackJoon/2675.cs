using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
string[] str = null;
int r = 0;
string s = null;

for (int i = 0; i < t; i++)
{
    str = Console.ReadLine().Split();
    r = int.Parse(str[0]);
    s = str[1];

    for (int j = 0; j < s.Length; j++)
    {
        for (int k = 0; k < r; k++)
        {
            sb.Append(s[j]);
        }
    }

    sb.AppendLine();
}

Console.WriteLine(sb.ToString());