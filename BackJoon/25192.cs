int n = int.Parse(Console.ReadLine());
string str = null;
Dictionary<string, int> dic = new Dictionary<string, int>();
int result = 0;

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    if (str == "ENTER")
    {
        dic.Clear();
        continue;
    }

    if (!dic.ContainsKey(str))
    {
        dic.Add(str, 1);
        result++;
    }

}

Console.WriteLine(result);