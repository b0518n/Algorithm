StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Dictionary<int, int> dic = new Dictionary<int, int>();

foreach (int tmp in input)
{
    if (!dic.ContainsKey(tmp))
    {
        dic.Add(tmp, 1);
    }
    else
    {
        dic[tmp]++;
    }
}

n = int.Parse(Console.ReadLine());
input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 0; i < input.Length; i++)
{
    if (dic.ContainsKey(input[i]))
    {
        if (i == input.Length - 1)
        {
            sw.Write(dic[input[i]]);
        }
        else
        {
            sw.Write(dic[input[i]] + " ");
        }
    }
    else
    {
        if (i == input.Length - 1)
        {
            sw.Write("0");
        }
        else
        {
            sw.Write("0 ");
        }
    }
}

sw.Close();