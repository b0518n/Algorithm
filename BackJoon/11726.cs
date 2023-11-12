using System.Numerics;

int n = 0;
int result = 0;
int a = 0; // 1 x 2 tile
int b = 0; // 2 x 1 tile


n = int.Parse(Console.ReadLine());
result = 0;

for (int i = 0; i <= n / 2; i++)
{
    a = n - (i * 2);
    b = i;

    result += (int)(Combination(a + b, b));
    result %= 10007;

}

Console.WriteLine(result);

long Combination(int n, int r)
{
    BigInteger fraction = 1;
    BigInteger denominator = 1;

    if (r == 0)
    {
        return 1;
    }
    else
    {
        for (int i = n; i > n - r; i--)
        {
            fraction *= i;
        }

        for (int i = r; i >= 1; i--)
        {
            denominator *= i;
        }

        return (long)((fraction / denominator) % 10007);
    }
}
