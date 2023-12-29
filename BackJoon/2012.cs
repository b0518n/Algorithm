int n = int.Parse(Console.ReadLine());
List<int> list = new List<int>();
long result = 0;

for (int i = 0; i < n; i++)
{
    list.Add(int.Parse(Console.ReadLine()));
}

list.Sort();

for (int i = 0; i < list.Count; i++)
{
    result += Math.Abs(list[i] - (i + 1));
}

Console.WriteLine(result);