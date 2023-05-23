using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
string[][] arr = new string[n][];
string[] input = null;
List<string> list = null;

for (int i = 0; i < n; i++)
{
    input = Console.ReadLine().Split();
    list = input.ToList();
    list.Add(i.ToString());
    arr[i] = list.ToArray();
}

Array.Sort(arr, (x, y) =>
{
    int compare = int.Parse(x[0]).CompareTo(int.Parse(y[0]));

    if (compare == 0)
    {
        compare = int.Parse(x[2]).CompareTo(int.Parse(y[2]));
    }

    return compare;
});

for (int i = 0; i < n; i++)
{
    sb.AppendLine($"{arr[i][0]} {arr[i][1]}");
}

Console.WriteLine(sb.ToString());