using System.Numerics;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int mod = 1000;

BigInteger[] input = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
BigInteger n = input[0];
BigInteger b = input[1];

int[,] arr = new int[(int)n, (int)n];
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), BigInteger.Parse);
    for (int j = 0; j < n; j++)
    {
        arr[i, j] = (int)input[j];
    }
}

int[,] result = Divide(arr, (int)n, b);
Print(result, (int)n);
sw.Flush();
sw.Close();
sr.Close();

void Print(int[,] arr, int n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (j == 0)
            {
                sw.Write(arr[i, j] % mod);
            }
            else
            {
                sw.Write(" " + arr[i, j] % mod);
            }
        }

        sw.WriteLine();
    }
}

int[,] Solve(int[,] arr1, int[,] arr2, int n)
{

    int[,] temp = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int l = 0; l < n; l++)
            {
                temp[i, j] += arr1[i, l] * arr2[l, j];
            }
            temp[i, j] %= mod;
        }
    }

    return temp;
}

int[,] Divide(int[,] arr, int n, BigInteger b)
{
    if (b == 1)
    {
        return arr;
    }
    else if (b == 2)
    {
        return Solve(arr, arr, n);
    }
    else
    {
        int[,] temp = Divide(arr, n, b / 2);

        if (b % 2 == 0)
        {
            return Solve(temp, temp, n);
        }
        else
        {
            return Solve(Solve(temp, temp, n), arr, n);
        }
    }
}