StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int s = input[1];

int[] sequence = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int start = 0;
int end = 0;
int value = sequence[start];
int minLength = int.MaxValue;
int length = 1;

while (true)
{
    if (s > value)
    {
        if (end == n - 1)
        {
            break;
        }

        end++;
        value += sequence[end];
        length++;
    }
    else
    {
        if (minLength > length)
        {
            minLength = length;
        }

        if (end > start)
        {
            value -= sequence[start];
            start++;
            length--;
        }
        else
        {
            if (end == n - 1)
            {
                break;
            }

            end++;
            value += sequence[end];
            length++;

        }
    }
}

if (minLength == int.MaxValue)
{
    sw.WriteLine(0);
}
else
{
    sw.WriteLine(minLength);
}

sw.Flush();
sw.Close();