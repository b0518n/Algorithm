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

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
int[] arr = new int[1000000];
int input = 0;
int count = 0;

for (int i = 2; i < 1000000; i++)
{
    if (isPrime(i))
    {
        arr[i] = 1;
    }
}

for (int i = 0; i < t; i++)
{
    input = int.Parse(Console.ReadLine());
    for (int j = 2; j < input / 2 + 1; j++)
    {
        if (arr[j] == 1)
        {
            if (arr[input - j] == 1)
            {
                count++;
            }
        }
    }

    sw.WriteLine(count);
    count = 0;
}

sw.Close();