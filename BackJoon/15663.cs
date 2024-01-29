using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] visited = new int[n];
Dictionary<string, int> dics = new Dictionary<string, int>();
Array.Sort(input);
BackTracking(new List<int>());
Console.WriteLine(sb.ToString());

void BackTracking(List<int> list)
{
    if (list.Count == m)
    {
        if (!dics.ContainsKey(string.Join(" ", list)))
        {
            dics.Add(string.Join(" ", list), 1);
            sb.AppendLine(string.Join(" ", list));
        }

        return;
    }

    for (int i = 0; i < n; i++)
    {
        if (visited[i] == 1)
        {
            continue;
        }

        visited[i] = 1;
        list.Add(input[i]);
        BackTracking(list);
        list.RemoveAt(list.Count - 1);
        visited[i] = 0;
    }
}