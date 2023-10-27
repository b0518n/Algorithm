string input = Console.ReadLine();
int length = input.Length;

int[] arr = new int[length];
Dictionary<int, int> dic = new Dictionary<int, int>();

for (int i = 0; i < length; i++)
{
    arr[i] = int.Parse(input[i].ToString());
}

int value = -1;

for (int i = 0; i < length; i++)
{
    if (i == 0)
    {
        value = arr[i];
    }
    else
    {
        if (value == arr[i])
        {
            continue;
        }
        else
        {
            if (!dic.ContainsKey(value))
            {
                dic.Add(value, 1);
            }
            else
            {
                dic[value]++;
            }

            value = arr[i];
        }
    }
}

if (dic.Count != 0)
{
    if (dic.ContainsKey(value))
    {
        dic[value]++;
    }
    else
    {
        dic.Add(value, 1);
    }
}

value = 0;

if (dic.Count != 0)
{
    foreach (int i in dic.Keys)
    {
        if (value == 0)
        {
            value = dic[i];
        }
        else
        {
            value = Math.Min(value, dic[i]);
        }
    }
}

Console.WriteLine(value);