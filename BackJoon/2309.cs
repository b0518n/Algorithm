int sum = 0;
List<int> list = new List<int>();
int n = 0;

for (int i = 0; i < 9; i++)
{
    n = int.Parse(Console.ReadLine());
    list.Add(n);
    sum += n;
}

sum -= 100;


for (int i = 0; i < list.Count; i++)
{
    for (int j = i + 1; j < list.Count; j++)
    {
        if (list[i] + list[j] == sum)
        {
            list.Remove(list[i]);
            list.Remove(list[j - 1]);
            goto outerLoop;
        }
    }
}

outerLoop:
list.Sort();
Console.WriteLine(string.Join("\n", list));