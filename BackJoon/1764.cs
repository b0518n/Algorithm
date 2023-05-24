StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
string str = string.Empty;
Dictionary<string, int> dic = new Dictionary<string, int>();
List<string> list = new List<string>();

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    dic.Add(str, 1);
}

for (int i = 0; i < m; i++)
{
    str = Console.ReadLine();
    if (dic.ContainsKey(str))
    {
        list.Add(str);
    }
}

list.Sort();
sw.WriteLine(list.Count);
for (int i = 0; i < list.Count; i++)
{
    sw.WriteLine(list[i]);
}

sw.Close();