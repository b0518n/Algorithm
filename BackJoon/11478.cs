string input = Console.ReadLine();
int size = 1;
Dictionary<string, int> dic = new Dictionary<string, int>();
string tmp = string.Empty;
while (true)
{
    for (int i = 0; i <= input.Length - size; i++)
    {
        tmp = input.Substring(i, size);
        if (!dic.ContainsKey(tmp))
        {
            dic.Add(tmp, 1);
        }
    }

    size++;

    if (size > input.Length)
    {
        break;
    }
}

Console.WriteLine(dic.Count);