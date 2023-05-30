StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

List<int> queue = new List<int>();
for (int i = 1; i <= n; i++)
{
    queue.Add(i);
}

int index = -1;
List<int> list = new List<int>();

while (true)
{
    if (queue.Count == 0)
    {
        break;
    }

    for (int i = 0; i < k; i++)
    {
        if (index + 1 <= queue.Count - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
    }

    list.Add(queue[index]);
    queue.RemoveAt(index);
    if (index == 0)
    {
        index = queue.Count - 1;
    }
    else
    {
        index--;
    }

}

if (list.Count == 1)
{
    sw.Write($"<{list[0]}>");
}
else
{
    for (int i = 0; i < list.Count; i++)
    {
        if (i == 0)
        {
            sw.Write($"<{list[i]}, ");
        }
        else if (i == list.Count - 1)
        {
            sw.Write($"{list[i]}>");
        }
        else
        {
            sw.Write($"{list[i]}, ");
        }
    }
}

sw.Close();