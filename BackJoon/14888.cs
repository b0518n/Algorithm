int n = int.Parse(Console.ReadLine());
int[] values = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] operators = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> stack = new List<int>();
int min = 100000001;
int max = -100000001;
int value = 0;
Solve();
Console.WriteLine(max);
Console.WriteLine(min);

void Solve()
{
    if (stack.Count == n - 1)
    {
        value = values[0];
        for (int i = 1; i <= stack.Count; i++)
        {
            if (stack[i - 1] == 0)
            {
                value += values[i];
            }
            else if (stack[i - 1] == 1)
            {
                value -= values[i];
            }
            else if (stack[i - 1] == 2)
            {
                value *= values[i];
            }
            else
            {
                value /= values[i];
            }
        }

        if (min > value)
        {
            min = value;
        }

        if (max < value)
        {
            max = value;
        }
        return;
    }

    for (int i = 0; i < operators.Length; i++)
    {
        if (operators[i] == 0)
        {
            continue;
        }

        stack.Add(i);
        operators[i]--;
        Solve();
        stack.RemoveAt(stack.Count - 1);
        operators[i]++;
    }
}