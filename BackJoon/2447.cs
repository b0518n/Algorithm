StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[,] arr = new int[n, n];
Recusion(arr, n, 0, 0);

void Recusion(int[,] arr, int n, int y, int x)
{
    if (n == 3)
    {
        arr[y, x] = 1;
        arr[y, x + 1] = 1;
        arr[y, x + 2] = 1;
        arr[y + 1, x] = 1;
        arr[y + 1, x + 1] = 0;
        arr[y + 1, x + 2] = 1;
        arr[y + 2, x] = 1;
        arr[y + 2, x + 1] = 1;
        arr[y + 2, x + 2] = 1;
    }
    else
    {
        Recusion(arr, n / 3, y, x);
        Recusion(arr, n / 3, y + n / 3, x);
        Recusion(arr, n / 3, y + 2 * (n / 3), x);

        Recusion(arr, n / 3, y, x + n / 3);
        Recusion(arr, n / 3, y + 2 * (n / 3), x + n / 3);

        Recusion(arr, n / 3, y, x + 2 * (n / 3));
        Recusion(arr, n / 3, y + n / 3, x + 2 * (n / 3));
        Recusion(arr, n / 3, y + 2 * (n / 3), x + 2 * (n / 3));
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (arr[i, j] == 1)
        {
            sw.Write("*");
        }
        else
        {
            sw.Write(" ");
        }

        if (j == n - 1)
        {
            sw.WriteLine();
        }
    }
}

sw.Close();