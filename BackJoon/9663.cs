int n = int.Parse(Console.ReadLine());
int[] rows = new int[n]; // rows 안의 값은 column
int result = 0;
Solve(0);

Console.WriteLine(result);
void Solve(int index)
{
    if (index == n)
    {
        result++;
        return;
    }
    else
    {
        for (int i = 0; i < n; i++)
        {
            rows[index] = i;
            if (CheckPosition(index))
            {
                Solve(index + 1);
            }
        }
    }
}

bool CheckPosition(int index)
{
    for (int i = 0; i < index; i++)
    {
        if (rows[index] == rows[i] || Math.Abs(rows[index] - rows[i]) == Math.Abs(index - i))
        {
            return false;
        }
    }

    return true;
}