StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[,,] arr = new int[101, 101, 101];
int a = 0;
int b = 0;
int c = 0;

Solve();
int[] input = null;

while (true)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    if (a == -1 && b == -1 && c == -1)
    {
        sw.Close();
        break;
    }

    sw.WriteLine($"w({a}, {b}, {c}) = {arr[a + 50, b + 50, c + 50]}");

}


void Solve()
{
    for (int i = 0; i <= 100; i++)
    {
        for (int j = 0; j <= 100; j++)
        {
            for (int k = 0; k <= 100; k++)
            {
                arr[i, j, k] = Recursion(i, j, k);
            }
        }
    }
}

int Recursion(int a, int b, int c)
{
    if (a <= 50 || b <= 50 || c <= 50)
    {
        return 1;
    }
    else if (a > 70 || b > 70 || c > 70)
    {
        return arr[70, 70, 70];
    }
    else if (a < b && b < c)
    {
        return arr[a, b, c - 1] + arr[a, b - 1, c - 1] - arr[a, b - 1, c];
    }
    else
    {
        return arr[a - 1, b, c] + arr[a - 1, b - 1, c] + arr[a - 1, b, c - 1] - arr[a - 1, b - 1, c - 1];
    }
}