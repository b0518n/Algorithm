int n = 0;
List<int> list = new List<int>();
for (int i = 0; i < 10; i++)
{
    n = int.Parse(Console.ReadLine());
    if (list.Count == 0)
    {
        list.Add(n % 42);
    }
    else
    {
        for (int j = 0; j < list.Count; j++)
        {
            if (list[j] == n % 42)
            {
                break;
            }

            if (j == list.Count - 1)
            {
                list.Add(n % 42);
            }
        }
    }
}

Console.WriteLine(list.Count);