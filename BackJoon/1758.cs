int n = int.Parse(Console.ReadLine());
List<int> list = new List<int>();
int input = 0;

for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    list.Add(input);
}

list.Sort((x, y) =>
{
    int compare = x.CompareTo(y) * -1;

    return compare;
});

int value = 0;
long result = 0;

int _value = -1;
for (int i = 0; i < n; i++)
{
    _value = list[i] - value;

    if (_value > 0)
    {
        result += _value;
    }

    value++;
}

Console.WriteLine(result);