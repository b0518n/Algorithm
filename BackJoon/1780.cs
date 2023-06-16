StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = null;

int n = int.Parse(sr.ReadLine());
int[,] arr = new int[n, n];

int minus = 0;
int zero = 0;
int plus = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        arr[i, j] = input[j];
    }
}

Divide(arr, n, 0, 0);
sw.WriteLine(minus);
sw.WriteLine(zero);
sw.WriteLine(plus);
sw.Flush();
sw.Close();
sr.Close();

void Divide(int[,] arr, int length, int y, int x)
{
    int value = 0;
    bool flag = false;

    for (int i = y; i < y + length; i++)
    {
        for (int j = x; j < x + length; j++)
        {
            if (i == y && j == x)
            {
                value = arr[i, j];
            }
            else
            {
                if (value != arr[i, j])
                {
                    flag = true;
                    break;
                }
            }
        }

        if (flag == true)
        {
            break;
        }
    }

    if (flag == true)
    {
        Divide(arr, length / 3, y, x);
        Divide(arr, length / 3, y, x + length / 3);
        Divide(arr, length / 3, y, x + 2 * length / 3);
        Divide(arr, length / 3, y + length / 3, x);
        Divide(arr, length / 3, y + length / 3, x + length / 3);
        Divide(arr, length / 3, y + length / 3, x + 2 * length / 3);
        Divide(arr, length / 3, y + 2 * length / 3, x);
        Divide(arr, length / 3, y + 2 * length / 3, x + length / 3);
        Divide(arr, length / 3, y + 2 * length / 3, x + 2 * length / 3);
    }
    else
    {
        if (value == -1)
        {
            minus++;
        }
        else if (value == 0)
        {
            zero++;
        }
        else if (value == 1)
        {
            plus++;
        }
    }
}