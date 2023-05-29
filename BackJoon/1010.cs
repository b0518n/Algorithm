using System.Numerics;

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
int[] input = null;
int n = 0;
int m = 0;
BigInteger numerator = 1;
BigInteger denominator = 1;
BigInteger result = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    m = input[1];

    for (int j = m; j > m - n; j--)
    {
        numerator *= j;
    }

    for (int j = n; j >= 1; j--)
    {
        denominator *= j;
    }

    result = numerator / denominator;
    sw.WriteLine(result);
    numerator = 1;
    denominator = 1;
}

sw.Close();