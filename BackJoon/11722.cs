int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> list = new List<int>();

for (int i = 0; i < n; i++)
{
    if (list.Count == 0)
    {
        list.Add(input[i]);
    }
    else
    {
        for (int j = list.Count - 1; j >= 0; j--)
        {
            if (list[j] < input[i])
            {
                if (j == 0)
                {
                    list[j] = input[i];
                }

                continue;
            }
            else if (list[j] > input[i])
            {
                if (j == list.Count - 1)
                {
                    list.Add(input[i]);
                }
                else
                {
                    list[j + 1] = input[i];
                }

                break;
            }
        }
    }
}

Console.WriteLine(list.Count);