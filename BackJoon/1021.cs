int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
List<int> temp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToList();
List<int> list = new List<int>();
int result = 0;

for (int i = 1; i <= n; i++)
{
    list.Add(i);
}

int count = 0;
int index = 0;

while (true)
{
    if (temp.Count == 0)
    {
        break;
    }

    while (true)
    {
        if (list[0] == temp[0])
        {
            if (count != 0)
            {
                if (list.Count - count > count)
                {
                    result += count;
                }
                else
                {
                    result += list.Count - count;
                }
            }

            list.RemoveAt(0);
            count = 0;
            break;
        }

        list.Add(list[0]);
        list.RemoveAt(0);
        count++;
    }

    temp.RemoveAt(0);

}

Console.WriteLine(result);