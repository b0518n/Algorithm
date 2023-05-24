StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

string str = string.Empty;
Dictionary<string, string> dic = new Dictionary<string, string>();
for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    dic.Add(str, (i + 1).ToString());
    dic.Add((i + 1).ToString(), str);
}

for (int j = 0; j < m; j++)
{
    str = Console.ReadLine();
    sw.WriteLine(dic[str]);
}

sw.Close();