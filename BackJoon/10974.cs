int n = int.Parse(Console.ReadLine());
List<string> list = new List<string>();
bool[] visited = new bool[n + 1];
Permutation(string.Empty);
list.Sort();

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(string.Join(" ", list[i].ToList()));
}

void Permutation(string str)
{
    if (str.Length == n)
    {
        list.Add(str);
        return;
    }

    for (int i = 1; i <= n; i++)
    {
        if (!visited[i])
        {
            str += $"{i}";
            visited[i] = true;
            Permutation(str);
            str = str.Substring(0, str.Length - 1);
            visited[i] = false;
        }
    }
}