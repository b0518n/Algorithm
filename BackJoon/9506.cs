using System.Text;

StringBuilder sb = new StringBuilder();
int n = 0;
List<int> list = new List<int>();

while (true)
{
    n = int.Parse(Console.ReadLine());
    if (n == -1)
    {
        break;
    }

    for (int i = 2; i < n; i++)
    {
        if (n % i == 0)
        {
            if (list.Contains(i) == false)
            {
                list.Add(i);
            }

            if (list.Contains(n / i) == false)
            {
                list.Add(n / i);
            }

        }
    }

    if (list.Sum() + 1 == n)
    {
        list.Sort();
        sb.Append($"{n} = 1");
        for (int k = 0; k < list.Count; k++)
        {
            sb.Append($" + {list[k]}");
        }
        sb.AppendLine();
    }
    else
    {
        sb.AppendLine($"{n} is NOT perfect.");
    }
    list.Clear();
}

Console.WriteLine(sb.ToString());