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

    Console.WriteLine(sb.ToString());
}

void solve(int x)
{
    for (int i = 2; i * i <= x; i++)
    {
        while (x % i == 0)
        {
            list.Add(i);
            x /= i;
        }
    }

    if (x != 1)
    {
        list.Add(x);
    }
}