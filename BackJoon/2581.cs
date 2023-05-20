using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
List<int> list = new List<int>();
if (n != 1)
{
    solve(n);
    list.Sort();

    for (int i = 0; i < list.Count; i++)
    {
        sb.AppendLine(list[i].ToString());
    }
}

Console.WriteLine(sb.ToString());

void solve(int x)
{
    for (int i = 2; i * i <= n; i++)
    {
        while (n % i == 0)
        {
            n /= i;
            list.Add(i);
        }
    }
}