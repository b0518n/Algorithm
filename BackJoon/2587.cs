using System.Text;

StringBuilder sb = new StringBuilder();
int n = 0;
List<int> list = new List<int>();
for (int i = 0; i < 5; i++)
{
    n = int.Parse(Console.ReadLine());
    list.Add(n);
}

list.Sort();
int avg = list.Sum() / 5;
int middle = list[2];

sb.AppendLine(avg.ToString());
sb.AppendLine(middle.ToString());
Console.WriteLine(sb.ToString());