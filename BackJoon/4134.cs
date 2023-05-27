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
long t = int.Parse(Console.ReadLine());
long input = 0;
long[] arr = new long[t];
for (int i = 0; i < t; i++)
{
    input = long.Parse(Console.ReadLine());
    arr[i] = input;
}

long index = 0;
long value = arr[index];
long j = value;

while (true)
{

    if (isPrime(j))
    {
        if (j >= value)
        {
            sw.WriteLine(j);
            index++;

            if (index == arr.Length)
            {
                break;
            }
            else
            {
                value = arr[index];
                j = value;
            }
        }
        else
        {
            j++;
        }
    }
    else
    {
        j++;
    }
}

sw.Close();