using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());

for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (j >= n + 1 - i)
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