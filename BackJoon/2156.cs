int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
list1.Add(0);
list2.Add(0);

for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        list1.Add(arr[i]);
        list2.Add(i + 1);
    }
    else
    {
        for (int j = list1.Count - 1; j >= 0; j--)
        {
            if (list1[j] < arr[i])
            {
                list2.Add(j + 1);
                if (j == list1.Count - 1)
                {
                    list1.Add(arr[i]);
                }

                break;
            }
        }
    }
}

Console.WriteLine(list2.Max());