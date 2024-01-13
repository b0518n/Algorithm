int n = int.Parse(Console.ReadLine());
int[] input = null;
int[,] costs = new int[n, n];
int minCost = -1;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        costs[i, j] = input[j];
    }
}

int[] check = new int[n];
List<int> sequence = new List<int>();
Permutation();
Console.WriteLine(minCost);

void Permutation()
{
    if (sequence.Count == n - 1)
    {
        CalcuateMinCost();
        return;
    }

    for (int i = 1; i < n; i++)
    {
        if (check[i] == 0)
        {
            sequence.Add(i);
            check[i] = 1;
            Permutation();
            check[i] = 0;
            sequence.RemoveAt(sequence.Count - 1);
        }
    }
}

void CalcuateMinCost()
{
    int value = 0;

    for (int i = 0; i < sequence.Count; i++)
    {
        if (i == 0)
        {
            if (costs[0, sequence[i]] == 0)
            {
                return;
            }

            value += costs[0, sequence[i]];
        }
        else
        {
            if (costs[sequence[i - 1], sequence[i]] == 0)
            {
                return;
            }

            value += costs[sequence[i - 1], sequence[i]];
        }
    }

    if (costs[sequence[sequence.Count - 1], 0] == 0)
    {
        return;
    }

    value += costs[sequence[sequence.Count - 1], 0];

    if (minCost == -1)
    {
        minCost = value;
    }
    else
    {
        minCost = Math.Min(minCost, value);
    }

    return;
}