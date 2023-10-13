int n = int.Parse(Console.ReadLine());
int w = 0;
List<int> ropes = new List<int>();

for (int i = 0; i < n; i++)
{
    w = int.Parse(Console.ReadLine());
    ropes.Add(w);
}

ropes.Sort();
int max = int.MinValue;
int value = 0;

for (int i = 0; i < n; i++)
{
    value = ropes[i] * (n - i);
    if (max < value)
    {
        max = value;
    }
}

Console.WriteLine(max);