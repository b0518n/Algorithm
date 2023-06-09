int n = int.Parse(Console.ReadLine());
int[] input = null;
int[] arr = new int[501];
List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
list1.Add(0);
list2.Add(0);

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    arr[input[0]] = input[1];
}

Solve();
Console.WriteLine(n - list1.Max());

void Solve()
{
    for (int i = 1; i <= 500; i++)
    {
        for (int j = list2.Count - 1; j >= 0; j--)
        {
            if (arr[i] == 0)
            {
                continue;
            }

            if (list2[j] < arr[i])
            {
                if (j == list2.Count - 1)
                {
                    list2.Add(arr[i]);
                }
                else
                {
                    list2[j + 1] = arr[i];
                }

                list1.Add(j + 1);
                break;
            }
        }
    }
}