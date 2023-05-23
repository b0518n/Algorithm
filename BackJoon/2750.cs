using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
int value = 0;
List<int> list = new List<int>();
for (int i = 0; i < n; i++)
{
    value = int.Parse(Console.ReadLine());
    list.Add(value);
}

list.Sort();

for (int i = 0; i < n; i++)
{
    sb.AppendLine(list[i].ToString());
}

Console.WriteLine(sb.ToString());