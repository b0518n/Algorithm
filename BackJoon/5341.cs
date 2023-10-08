int n = 0;
int result = 0;

StringBuilder sb = new StringBuilder();

while (true)
{
    n = int.Parse(Console.ReadLine());
    if (n == 0)
    {
        break;
    }

    for (int i = 1; i < n + 1; i++)
    {
        result += i;
    }

    sb.AppendLine(result.ToString());
    result = 0;
}

Console.WriteLine(sb.ToString());