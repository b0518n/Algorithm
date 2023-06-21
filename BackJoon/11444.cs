using System.Numerics;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int mod = 1000000007;
BigInteger n = BigInteger.Parse(sr.ReadLine());
long[,] arr = new long[2, 2] { { 1, 1 }, { 1, 0 } };
long[,] result = Divide(arr, 2, n);
sw.WriteLine(result[0, 1]);
sw.Flush();
sw.Close();
sr.Close();

long[,] Divide(long[,] arr, int size, BigInteger n)
{
    if (n == 1)
    {
        return arr;
    }
    else if (n == 2)
    {
        return Solve(arr, arr, size);
    }
    else
    {
        long[,] temp = Divide(arr, size, n / 2);
        if (n % 2 == 0)
        {
            return Solve(temp, temp, size);
        }
        else
        {
            return Solve(Solve(temp, temp, size), arr, size);
        }
    }
}

long[,] Solve(long[,] arr1, long[,] arr2, int size)
{
    long[,] temp = new long[size, size];

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            for (int l = 0; l < size; l++)
            {
                temp[i, j] += arr1[i, l] * arr2[l, j];
            }

            temp[i, j] %= mod;
        }
    }

    return temp;
}