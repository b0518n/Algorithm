using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n - 1 - i; j++)
    {
        sb.Append(" ");
    }

    for (int j = 0; j < (2 * i) + 1; j++)
    {
        sb.Append("*");
    }

    sb.AppendLine();
}

for (int i = n - 2; i >= 0; i--)
{
    for (int j = 0; j < n - 1 - i; j++)
    {
        sb.Append(" ");
    }

    for (int j = 0; j < (2 * i) + 1; j++)
    {
        sb.Append("*");
    }

    if (i != 0)
    {
        sb.AppendLine();
    }
}

Console.WriteLine(sb.ToString());