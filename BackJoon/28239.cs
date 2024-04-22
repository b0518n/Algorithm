StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
List<long> list = new List<long>();
List<int> result = new List<int>();

for (int i = 0; i < n; i++)
{
    list.Add(long.Parse(sr.ReadLine()));
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < 64; j++)
    {
        if ((list[i] & (long)1 << j) != 0)
        {
            result.Add(j);
        }
    }

    if (result.Count == 1)
    {
        int tValue = result[0] - 1;
        result.RemoveAt(0);
        result.Add(tValue);
        result.Add(tValue);
        sw.WriteLine(string.Join(" ", result));
    }
    else
    {
        sw.WriteLine(string.Join(" ", result));
    }
    result.Clear();
}

sw.Flush();
sw.Close();