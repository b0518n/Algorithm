StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int a = 0;
int b = 0;
Dictionary<long, int> dictionary = new Dictionary<long, int>();

int index = 0;
long value = 0;

while (true)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];

    if (a == 0 && b == 0)
    {
        break;
    }

    index = 0;
    value = a;

    dictionary.Clear();
    dictionary.Add(a, index);
    index++;

    while (true)
    {
        if (value == 1)
        {
            break;
        }

        if (value % 2 == 0)
        {
            value = value / 2;
        }
        else
        {
            value = (3 * value) + 1;
        }

        dictionary.Add(value, index);
        index++;
    }

    index = 0;
    value = b;

    while (true)
    {
        if (dictionary.ContainsKey(value))
        {
            sw.WriteLine($"{a} needs {dictionary[value]} steps, {b} needs {index} steps, they meet at {value}");
            break;
        }
        else
        {
            if (value % 2 == 0)
            {
                value = value / 2;
            }
            else
            {
                value = (3 * value) + 1;
            }

            index++;
        }
    }
}

sw.Flush();
sw.Close();