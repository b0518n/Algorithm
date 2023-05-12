int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
List<int> costs = new List<int>();
int count = 0;
int mok = 0;
int nmg = 0;

for (int i = 0; i < n; i++)
{
    costs.Add(int.Parse(Console.ReadLine()));
}

for (int i = n - 1; i >= 0; i--)
{
    if (k == 0)
    {
        break;
    }
    else if (k < costs[i])
    {
        continue;
    }
    else
    {
        mok = k / costs[i];
        nmg = k % costs[i];
        k = nmg;
        count += mok;
    }
}

Console.WriteLine(count);