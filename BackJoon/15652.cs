int n = int.Parse(Console.ReadLine());
int[,] arr = new int[n, n];
int result = 0;
Select(arr, 0, 0, 0);
Console.WriteLine(result);

void Select(int[,] arr, int count, int x, int y)
{
    if (count == n)
    {
        result++;
        return;
    }

    int i = x;
    int j = y;

    while (true)
    {
        if (arr[i, j] == 0)
        {
            count++;
            arr[i, j] = 1;
            Constraint(arr, i, j);
            Select(arr, count, i, j);
            count--;
            arr[i, j] = 0;

        }

        if (j == n - 1)
        {
            if (i == n - 1)
            {
                break;
            }
            else
            {
                i++;
                j = 0;
            }
        }
        else
        {
            j++;
        }

    }
}

void Constraint(int[,] arr, int y, int x)
{
    Constraint_Colum(arr, y, x);
    Constraint_Row(arr, y, x);
    Constraint_Cross(arr, y, x);
}

void Constraint_Row(int[,] arr, int y, int x)
{
    for (int j = 1; j < n; j++)
    {
        Constraint_Row_Plus(arr, j, y, x);
        Constraint_Row_Minus(arr, j, y, x);
    }
}

void Constraint_Row_Plus(int[,] arr, int i, int y, int x)
{
    if (y + i > n - 1)
    {
        return;
    }

    if (arr[y + i, x] == 1)
    {
        return;
    }
    else
    {
        arr[y + i, x]--;
        return;
    }
}

void Constraint_Row_Minus(int[,] arr, int i, int y, int x)
{
    if (y - i < 0)
    {
        return;
    }

    if (arr[y - i, x] == 1)
    {
        return;
    }
    else
    {
        arr[y - i, x]--;
        return;
    }
}

void Constraint_Colum(int[,] arr, int y, int x)
{
    for (int j = 1; j < n; j++)
    {
        Constraint_Colum_Plus(arr, j, y, x);
        Constraint_Colum_Minus(arr, j, y, x);
    }
}

void Constraint_Colum_Plus(int[,] arr, int i, int y, int x)
{
    if (x + i > n - 1)
    {
        return;
    }

    if (arr[y, x + i] == 1)
    {
        return;
    }
    else
    {
        arr[y, x + i]--;
        return;
    }
}

void Constraint_Colum_Minus(int[,] arr, int i, int y, int x)
{
    if (x - i < 0)
    {
        return;
    }

    if (arr[y, x - i] == 1)
    {
        return;
    }
    else
    {
        arr[y, x - i]--;
        return;
    }
}

void Constraint_Cross(int[,] arr, int y, int x)
{
    for (int j = 1; j < n; j++)
    {
        Constraint_Cross_TopLeft(arr, j, y, x);
        Constraint_Cross_TopRight(arr, j, y, x);
        Constraint_Cross_BottomLeft(arr, j, y, x);
        Constraint_Cross_BottomRight(arr, j, y, x);
    }
}

void Constraint_Cross_TopLeft(int[,] arr, int i, int y, int x)
{
    if (y - i < 0 || x - i < 0)
    {
        return;
    }

    if (arr[y - i, x - i] == 1)
    {
        return;
    }
    else
    {
        arr[y - i, x - i]--;
        return;
    }
}

void Constraint_Cross_TopRight(int[,] arr, int i, int y, int x)
{
    if (y - i < 0 || x + i > n - 1)
    {
        return;
    }

    if (arr[y - i, x + i] == 1)
    {
        return;
    }
    else
    {
        arr[y - i, x + i]--;
        return;
    }
}

void Constraint_Cross_BottomLeft(int[,] arr, int i, int y, int x)
{
    if (y + i > n - 1 || x - i < 0)
    {
        return;
    }

    if (arr[y + i, x - i] == 1)
    {
        return;
    }
    else
    {
        arr[y + i, x - i]--;
        return;
    }
}

void Constraint_Cross_BottomRight(int[,] arr, int i, int y, int x)
{
    if (y + i > n - 1 || x + i > n - 1)
    {
        return;
    }

    if (arr[y + i, x + i] == 1)
    {
        return;
    }
    else
    {
        arr[y + i, x + i]--;
        return;
    }
}

