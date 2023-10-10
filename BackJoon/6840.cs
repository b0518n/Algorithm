List<int> weights = new List<int>();
for (int i = 0; i < 3; i++)
{
    weights.Add(int.Parse(Console.ReadLine()));
}

weights.Sort();
Console.WriteLine(weights[1]);