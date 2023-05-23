using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
List<string> list = new List<string>();
string input = null;
for (int i = 0; i < n; i++)
{
    input = Console.ReadLine();
    if (i == 0)
    {
        list.Add(input);
    }
    else
    {
        if (!list.Contains(input))
        {
            list.Add(input);
        }
    }
}

if (n > 1)
{
    list.Sort((x, y) =>
    {
        int compare = 0;
        if (x.Length == y.Length)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    compare = x[i].CompareTo(y[i]);
                    break;
                }
            }
        }
        else
        {
            compare = x.Length.CompareTo(y.Length);
        }

        return compare;
    });
}

for (int i = 0; i < list.Count; i++)
{
    sb.AppendLine(list[i]);
}

Console.WriteLine(sb.ToString());