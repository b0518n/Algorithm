using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(input);
BackTracking(0, new List<int>());
Console.WriteLine(sb.ToString());

void BackTracking(int start, List<int> list)
{
    if (list.Count == m)
    {
        sb.AppendLine(string.Join(" ", list));
        return;
    }

    for (int i = start; i < n; i++)
    {
        list.Add(input[i]);
        BackTracking(i, list);
        list.RemoveAt(list.Count - 1);
    }
}