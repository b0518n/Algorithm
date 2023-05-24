StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
Dictionary<int, int> dic = new Dictionary<int, int>();
int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 0; i < n; i++)
{
    if (!dic.ContainsKey(input[i]))
    {
        dic.Add(input[i], 1);
    }
}

int m = int.Parse(Console.ReadLine());
input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 0; i < m; i++)
{
    if (dic.ContainsKey(input[i]))
    {
        input[i] = 1;
    }
    else
    {
        input[i] = 0;
    }

    if (i == 0)
    {
        sw.Write(input[i]);
    }
    else
    {
        sw.Write(" " + input[i]);
    }
}

sw.Close();