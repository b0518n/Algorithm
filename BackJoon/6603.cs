using System.Text;

StringBuilder sb = new StringBuilder();
string input = null;
int[] temp = null;
int k = 0;
List<int> list = new List<int>();

while (true)
{
    input = Console.ReadLine();
    if (input.Length == 1)
    {
        break;
    }

    if (sb.Length != 0)
    {
        sb.AppendLine();
    }

    temp = Array.ConvertAll(input.Split(" "), int.Parse);
    k = temp[0];
    for (int i = 1; i < k + 1; i++)
    {
        list.Add(temp[i]);
    }

    SelectElement(0, new List<int>());
    list.Clear();
}

Console.WriteLine(sb.ToString());

void SelectElement(int start, List<int> container)
{
    if (container.Count == 6)
    {
        sb.AppendLine(string.Join(" ", container));
        return;
    }

    for (int i = start; i < k; i++)
    {
        container.Add(list[i]);
        SelectElement(i + 1, container);
        container.RemoveAt(container.Count - 1);
    }
}