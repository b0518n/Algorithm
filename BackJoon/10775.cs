int g = int.Parse(Console.ReadLine());
int p = int.Parse(Console.ReadLine());

int[] gates = new int[g + 1];
int[] planes = new int[p + 1];
for (int i = 0; i < g + 1; i++)
{
    gates[i] = i;
}

for (int i = 1; i < p + 1; i++)
{
    planes[i] = int.Parse(Console.ReadLine());
}

int result = 0;
int index = 0;

for (int i = 1; i < p + 1; i++)
{
    index = find(planes[i]);
    if (gates[index] == 0)
    {
        break;
    }
    else
    {
        gates[index] = index - 1;
        result++;
    }
}

Console.WriteLine(result);

int find(int v)
{
    if (gates[v] == v)
    {
        return v;
    }
    else
    {
        gates[v] = find(gates[v]);
        return gates[v];
    }
}