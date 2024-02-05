using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
Dictionary<string, int> dic = new Dictionary<string, int>();
input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
Array.Sort(input);
List<int> list = new List<int>();
StringBuilder sb = new StringBuilder();
BackTracking();
Console.WriteLine(sb.ToString());

void BackTracking()
{
    if (list.Count == m)
    {
        if (!dic.ContainsKey(string.Join(" ", list)))
        {
            dic.Add(string.Join(" ", list), 1);
            sb.AppendLine(string.Join(" ", list));
        }

        return;
    }

    for (int i = 0; i < n; i++)
    {
        list.Add(input[i]);
        BackTracking();
        list.RemoveAt(list.Count - 1);
    }
}