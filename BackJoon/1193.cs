List<int> list = new List<int>();
list.Add(1);
int x = 1;
int tmp = 0;
while (true)
{
    tmp = list.Last() + 6 * x;
    if (tmp > 1000000000)
    {
        break;
    }

    list.Add(tmp);
    x++;
}

int n = int.Parse(Console.ReadLine());
int result = 0;
for (int i = 0; i < list.Count; i++)
{
    if (list[i] >= n)
    {
        result = i;
        break;
    }
}

Console.WriteLine(result + 1);