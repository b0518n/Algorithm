using System.Text;

bool isPrime(long n)
{
    if (n == 0 || n == 1)
    {
        return false;
    }

    if (n == 2)
    {
        return true;
    }

    for (int i = 2; i < Math.Sqrt(n) + 1; i++)
    {
        if (n % i == 0)
        {
            return false;
        }
    }

    return true;
}

StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int m = input[0];
int n = input[1];

for (int i = m; i < n + 1; i++)
{
    if (isPrime(i))
    {
        sw.WriteLine(i);
    }
}

sw.Close();