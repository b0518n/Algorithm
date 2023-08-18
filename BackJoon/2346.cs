int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] visited = new int[n];

List<int> result = new List<int>();
int index = 0;
while (true)
{
    result.Add(index);
    visited[index] = 1;

    if (result.Count == n)
    {
        break;
    }

    int value = arr[index];
    if (value < 0)
    {
        for (int i = 0; i < Math.Abs(value); i++)
        {
            index--;
            if (index == -1)
            {
                index = n - 1;
            }

            if (visited[index] == 1)
            {
                i--;
            }
        }
    }
    else
    {
        for (int i = 0; i < Math.Abs(value); i++)
        {
            index++;
            if (index == n)
            {
                index = 0;
            }

            if (visited[index] == 1)
            {
                i--;
            }
        }
    }
}

for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        Console.Write(result[i] + 1);
    }
    else
    {
        Console.Write(" " + (result[i] + 1));
    }
}