StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
string str = null;
List<char> list = new List<char>();
for (int i = 0; i < t; i++)
{
    str = Console.ReadLine();
    for (
        int j = 0; j < str.Length; j++)
    {
        if (j == 0)
        {
            list.Add(str[j]);
        }
        else
        {
            if (str[j] == ')')
            {
                if (list.Count == 0)
                {
                    list.Add(str[j]);
                    continue;
                }

                if (list[list.Count - 1] == '(')
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
            else
            {
                list.Add(str[j]);
            }
        }
    }

    if (list.Count == 0)
    {
        sw.WriteLine("YES");
    }
    else
    {
        sw.WriteLine("NO");
    }

    list.Clear();
}
sw.Close();