int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int l = input[1];

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> list = input.ToList();
list.Sort();
list.Reverse();

while (true)
{
    if (list.Count == 0)
    {
        break;
    }

    if (l >= list[list.Count - 1])
    {
        l++;
        list.RemoveAt(list.Count - 1);
    }
    else
    {
        break;
    }
}

Console.WriteLine(l);