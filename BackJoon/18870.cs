using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
Dictionary<int, int> dic = new Dictionary<int, int>();
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] arr1 = (int[])arr.Clone();
Array.Sort(arr1);
int index = 0;
for (int i = 0; i < n; i++)
{
    if (!dic.ContainsKey(arr1[i]))
    {
        dic[arr1[i]] = index;
        index++;
    }
}

for (int i = 0; i < n; i++)
{
    arr[i] = dic[arr[i]];
    if (i == n - 1)
    {
        sb.Append(arr[i]);
    }
    else
    {
        sb.Append(arr[i] + " ");
    }
}

Console.WriteLine(sb.ToString());