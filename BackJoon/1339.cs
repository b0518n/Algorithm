int n = int.Parse(Console.ReadLine());
string str = null;
Dictionary<string, int> dics = new Dictionary<string, int>();
int digit = 1;

for (int i = 0; i < n; i++)
{
    digit = 1;
    str = Console.ReadLine();
    for (int j = str.Length - 1; j >= 0; j--)
    {
        if (dics.ContainsKey(str[j].ToString()))
        {
            dics[str[j].ToString()] += digit;
        }
        else
        {
            dics.Add(str[j].ToString(), digit);
        }

        digit *= 10;
    }
}

List<int> list = dics.Values.ToList();
list.Sort();

int value = 9;
int result = 0;

for (int i = list.Count - 1; i >= 0; i--)
{
    result += list[i] * value;
    value--;
}

Console.WriteLine(result);