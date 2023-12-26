int n = int.Parse(Console.ReadLine());
int[] values = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] diceMinValues = new int[4];
long result = 0;
// 2개 : A - F, B - E, C - D 평행한 면이기 때문에 min값 x
// A - F : 0 - 5, B - E : 1 - 4, C - D : 2 - 3

// 최소인 면 (1개)
int min = -1;
for (int i = 0; i < 6; i++)
{
    if (min == -1)
    {
        min = values[i];
    }
    else
    {
        min = Math.Min(min, values[i]);
    }
}

diceMinValues[1] = min;

// 최소인 면 (2개)
min = -1;
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        if (i == j)
        {
            continue;
        }

        if (i + j == 5)
        {
            continue;
        }

        if (min == -1)
        {
            min = values[i] + values[j];
        }
        else
        {
            min = Math.Min(min, values[i] + values[j]);
        }
    }
}

diceMinValues[2] = min;

// 최소인 면 (3개)
min = -1;
for (int i = 0; i < 6; i++)
{
    for (int j = 0; j < 6; j++)
    {
        if (i == j || i + j == 5)
        {
            continue;
        }
        for (int k = 0; k < 6; k++)
        {
            if (i == k || j == k || i + k == 5 || j + k == 5)
            {
                continue;
            }

            if (min == -1)
            {
                min = values[i] + values[j] + values[k];
            }
            else
            {
                min = Math.Min(min, values[i] + values[j] + values[k]);
            }
        }
    }
}

diceMinValues[3] = min;
Array.Sort(values);

if (n == 1)
{
    result = values[0] + values[1] + values[2] + values[3] + values[4];
}
else
{
    for (int i = 0; i < n; i++)
    {
        if (i == 0)
        {
            result += (diceMinValues[3] * 4) + ((n - 2) * 4) * diceMinValues[2] + (n - 2 > 0 ? (long)(n - 2) * (n - 2) * diceMinValues[1] : 0);
        }
        else
        {
            result += (diceMinValues[2] * 4) + ((n - 2) * 4) * diceMinValues[1] + (n - 2 > 0 ? (long)(n - 2) * (n - 2) * diceMinValues[0] : 0);
        }
    }
}

Console.WriteLine(result);