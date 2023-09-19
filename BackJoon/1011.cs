int n = int.Parse(Console.ReadLine());
int[] input = null;
StringBuilder sb = new StringBuilder();
int start = 0;
int end = 0;
long k = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    start = 0;
    end = input[1] - input[0];
    k = 0;

    while (true)
    {
        if (k * k == end)
        {
            sb.AppendLine((k + k - 1).ToString());
            break;
        }
        else if (k * k > end)
        {
            long value = (k - 1) * (k - 1);
            long _value = end - value;
            if (_value > k - 1)
            {
                sb.AppendLine((k - 1 + k - 2 + 2).ToString());
            }
            else
            {
                sb.AppendLine((k - 1 + k - 2 + 1).ToString());
            }

            break;
        }
        else
        {
            k++;
        }
    }
}

Console.WriteLine(sb.ToString());