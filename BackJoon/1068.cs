int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int index = int.Parse(Console.ReadLine());

Dictionary<int, List<int>> dics = new Dictionary<int, List<int>>();
for (int i = 0; i < input.Length; i++)
{
    if (input[i] == -1)
    {
        continue;
    }

    if (!dics.ContainsKey(input[i]))
    {
        dics.Add(input[i], new List<int>());
        dics[input[i]].Add(i);
    }
    else
    {
        dics[input[i]].Add(i);
    }
}

Console.WriteLine(n - DFS(index) - dics.Count);

int DFS(int index)
{
    Stack<int> stack = new Stack<int>();
    stack.Push(index);
    int count = 0;

    int temp = 0;

    while (stack.Count > 0)
    {
        temp = stack.Pop();
        count++;

        if (dics.ContainsKey(temp))
        {
            foreach (int i in dics[temp])
            {
                stack.Push(i);
            }

            dics.Remove(temp);
        }

        if (dics.ContainsKey(input[temp]))
        {
            dics[input[temp]].Remove(temp);
            if (dics[input[temp]].Count == 0)
            {
                dics.Remove(input[temp]);
            }
        }
    }

    return count;
}
