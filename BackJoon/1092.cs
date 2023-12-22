int n = int.Parse(Console.ReadLine());
int[] crains = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(crains);
int m = int.Parse(Console.ReadLine());
int[] boxs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

List<int> list = new List<int>();
for (int i = 0; i < m; i++)
{
    list.Add(boxs[i]);
}

list.Sort();
int result = 0;
int maxWeight = crains[crains.Length - 1];

if (list[list.Count - 1] > maxWeight)
{
    result = -1;
}
else
{
    while (list.Count > 0)
    {
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = list.Count - 1; j >= 0; j--)
            {
                if (crains[i] >= list[j])
                {
                    list.RemoveAt(j);
                    break;
                }
            }
        }

        result++;
    }
}

Console.WriteLine(result);
