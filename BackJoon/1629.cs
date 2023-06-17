using System.Numerics;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int c = input[2];

BigInteger result = Solve(a, b, c);
sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();

BigInteger Solve(int x, int y, int z)
{
    if (y == 0)
    {
        return 1;
    }
    else if (y == 1)
    {
        return x % z;
    }
    else
    {
        BigInteger tmp = Solve(x, y / 2, z);
        if (y % 2 == 0)
        {
            return tmp * tmp % z;
        }
        else
        {
            return tmp * tmp * x % z;
        }
    }
}