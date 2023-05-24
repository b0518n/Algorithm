int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[] tmp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Dictionary<int, int> dic1 = new Dictionary<int, int>();
Dictionary<int, int> dic2 = new Dictionary<int, int>();
for (int i = 0; i < n; i++)
{
    dic1.Add(tmp[i], 1);
}

tmp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 0; i < m; i++)
{
    dic2.Add(tmp[i], 1);
}

int count1 = 0;
int count2 = 0;

foreach (int i in dic1.Keys)
{
    if (!dic2.ContainsKey(i))
    {
        count1++;
    }
}

foreach (int i in dic2.Keys)
{
    if (!dic1.ContainsKey(i))
    {
        count2++;
    }
}

Console.WriteLine(count1 + count2);