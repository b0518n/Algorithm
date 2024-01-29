using System.Text;

StreamReader reader = new StreamReader(Console.OpenStandardInput());
StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
StringBuilder sb = new StringBuilder();
string[] input = reader.ReadLine().Split();
int n = int.Parse(input[0]);
int m = int.Parse(input[1]);

input = reader.ReadLine().Split();
int[] arr = new int[n];
Dictionary<string, int> dics = new Dictionary<string, int>();

for (int i = 0; i < n; i++)
{
    arr[i] = int.Parse(input[i]);
}

Array.Sort(arr);
BackTracking(0, new List<int>());
writer.Write(sb.ToString());
writer.Close();

void BackTracking(int start, List<int> list)
{
    if (list.Count == m)
    {
        if (!dics.ContainsKey(string.Join(" ", list)))
        {
            PrintList(list);
            dics.Add(string.Join(" ", list), 1);
        }
        return;
    }

    for (int i = start; i < n; i++)
    {
        list.Add(arr[i]);
        BackTracking(i, list);
        list.RemoveAt(list.Count - 1);
    }
}

void PrintList(List<int> list)
{
    for (int i = 0; i < m; i++)
    {
        if (i == m - 1)
        {
            sb.AppendLine(list[i].ToString());
        }
        else
        {
            sb.Append(list[i].ToString() + " ");
        }
    }
}