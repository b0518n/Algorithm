int n = int.Parse(Console.ReadLine());
int value = int.Parse(Console.ReadLine());
int max = -1;
Dictionary<int, int> dics = new Dictionary<int, int>();
int input = 0;
int result = 0;

for (int i = 1; i < n; i++)
{
    input = int.Parse(Console.ReadLine());

    if (dics.ContainsKey(input))
    {
        dics[input]++;
    }
    else
    {
        dics.Add(input, 1);
        max = Math.Max(max, input);
    }
}

while (true)
{
    if (max >= value)
    {
        value++;
        if (dics[max] > 1)
        {
            dics[max]--;
            if (dics.ContainsKey(max - 1))
            {
                dics[max - 1]++;
            }
            else
            {
                dics.Add(max - 1, 1);
            }
        }
        else
        {
            dics.Remove(max);
            if (dics.ContainsKey(max - 1))
            {
                dics[max - 1]++;
            }
            else
            {
                dics.Add(max - 1, 1);
            }

            max--;
        }

        result++;
    }
    else
    {
        break;
    }
}

Console.WriteLine(result);