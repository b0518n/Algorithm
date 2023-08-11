StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
int n = int.Parse(Console.ReadLine());
List<int> Primes = new List<int>();

AddPrime(Primes, n);
TwoPointer(Primes, n);
sw.Close();

void AddPrime(List<int> Primes, int maxValue)
{
    bool isPrime = true;

    for (int i = 2; i <= maxValue; i++)
    {
        isPrime = true;

        for (int j = 2; j <= Math.Sqrt(i); j++)
        {
            if (!isPrime)
            {
                break;
            }

            if (i % j == 0)
            {
                isPrime = false;
            }
        }

        if (isPrime)
        {
            Primes.Add(i);
        }
    }
}

void TwoPointer(List<int> list, int n)
{
    if (n == 1)
    {
        PrintCount(0);
    }
    else
    {
        int count = 0;
        int start = 0;
        int end = 0;
        int value = list[start];

        while (true)
        {
            if (value < n)
            {
                if (end == list.Count - 1)
                {
                    break;
                }

                end++;
                value += list[end];
            }
            else if (value > n)
            {
                if (start < end)
                {
                    value -= list[start];
                    start++;
                }
                else
                {
                    if (end == list.Count - 1)
                    {
                        break;
                    }

                    end++;
                    value += list[end];
                }
            }
            else
            {
                count++;
                if (end == list.Count - 1)
                {
                    break;
                }
                else
                {
                    end++;
                    value += list[end];
                }
            }
        }

        PrintCount(count);
    }
}

void PrintCount(int count)
{
    sw.WriteLine(count);
    sw.Flush();
}