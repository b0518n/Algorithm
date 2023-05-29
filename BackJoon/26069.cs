StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

string str = null;
Dictionary<string, int> dic = new Dictionary<string, int>();
for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    if (str.Length < m)
    {
        continue;
    }

    if (dic.ContainsKey(str))
    {
        dic[str]++;
    }
    else
    {
        dic.Add(str, 1);
    }
}

Array[] arr = new Array[dic.Count];
int index = 0;
foreach (string tmp in dic.Keys)
{
    arr[index] = new string[2] { tmp, dic[tmp].ToString() };
    index++;
}

Array.Sort(arr, (x, y) =>
{
    int compare = int.Parse((string)x.GetValue(1)).CompareTo(int.Parse((string)y.GetValue(1)));

    if (compare == 0)
    {
        compare = ((string)x.GetValue(0)).Length.CompareTo(((string)y.GetValue(0)).Length);
        if (compare == 0)
        {
            compare = -1 * ((string)x.GetValue(0)).CompareTo((string)y.GetValue(0));
        }
    }

    return compare;
});

Array.Reverse(arr);

foreach (string[] tmp in arr)
{
    sw.WriteLine(tmp[0]);
}

sw.Close();