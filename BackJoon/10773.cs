int k = int.Parse(Console.ReadLine());
int input = 0;
List<int> list = new List<int>();
for (int i = 0; i < k; i++)
{
    input = int.Parse(Console.ReadLine());
    if (input == 0)
    {
        list.RemoveAt(list.Count - 1);
    }
    else
    {
        list.Add(input);
    }
}

Console.WriteLine(list.Sum());