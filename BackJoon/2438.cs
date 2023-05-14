using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (i + j >= 4)
        {
            sb.Append("*");
        }
        else
        {
            sb.Append(" ");
        }
    }

    sb.AppendLine();
}

Console.WriteLine(sb.ToString());