StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
List<string> list = new List<string>();
hanoi(n, 1, 2, 3);

sw.WriteLine(list.Count);
for (int i = 0; i < list.Count; i++)
{
    sw.WriteLine($"{list[i][0]} {list[i][2]}");
}

sw.Close();

void hanoi(int n, int start, int mid, int end)
{
    if (n == 1)
    {
        list.Add(start.ToString() + " " + end.ToString());
        return;
    }

    hanoi(n - 1, start, end, mid);
    list.Add(start.ToString() + " " + end.ToString());
    hanoi(n - 1, mid, start, end);
}