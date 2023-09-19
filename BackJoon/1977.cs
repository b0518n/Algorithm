int m = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());

int min = 10001;
int sum = 0;

for (int i = 1; i <= 100; i++)
{
    if (i * i >= m && i * i <= n)
    {
        min = Math.Min(min, i * i);
        sum += i * i;
    }
}

StringBuilder sb = new StringBuilder();
if (sum == 0)
{
    sb.AppendLine((-1).ToString());
}
else
{
    sb.AppendLine(sum.ToString());
    sb.AppendLine(min.ToString());
}

Console.WriteLine(sb.ToString());