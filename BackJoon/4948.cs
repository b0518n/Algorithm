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
int input = 0;
int count = 0;
while (true)
{
    input = int.Parse(Console.ReadLine());
    if (input == 0)
    {
        break;
    }

    count = 0;
    for (int i = input + 1; i <= 2 * input; i++)
    {
        if (isPrime(i))
        {
            count++;
        }
    }

    sw.WriteLine(count);
    count = 0;
}

sw.Close();