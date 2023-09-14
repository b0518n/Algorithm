int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int result = 0;
foreach (IEnumerable<int> i in GetPermutations(input))
{
    UpdateCount(i.ToList(), ref result);
}

Console.WriteLine(result);

/// <summary>
/// 순열을 구하는 식
/// </summary>
static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items)
{
    int count = items.Count();

    if (count == 1)
    {
        yield return items;
    }

    for (int i = 0; i < count; i++)
    {
        T item = items.ElementAt(i);
        IEnumerable<T> remaining = items.Take(i).Concat(items.Skip(i + 1));
        foreach (IEnumerable<T> permutation in GetPermutations(remaining))
        {
            yield return new List<T> { item }.Concat(permutation);
        }
    }
}

static bool Check(List<int> items, int start)
{
    int a = items[start];
    int b = 0;
    int c = 0;

    if (start == 6)
    {
        b = items[start + 1];
        c = items[0];
    }
    else if (start == 7)
    {
        b = items[0];
        c = items[1];
    }
    else
    {
        b = items[start + 1];
        c = items[start + 2];
    }

    if ((a * c) * Math.Sqrt(2) <= b * (a + c))
    {
        return true;
    }
    else
    {
        return false;
    }

}

static void UpdateCount(List<int> items, ref int result)
{
    for (int i = 0; i < items.Count; i++)
    {
        if (!Check(items, i))
        {
            return;
        }
    }

    result++;
    return;
}