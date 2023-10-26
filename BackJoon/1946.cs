int t = int.Parse(Console.ReadLine());
int n = 0;
int[] input = null;

List<List<int>> list = null;

int result = 0;
int rank = -1;

for (int i = 0; i < t; i++)
{
    n = int.Parse(Console.ReadLine());
    list = new List<List<int>>();

    for (int j = 0; j < n; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        list.Add(new List<int>() { input[0], input[1] });
    }

    list.Sort((a, b) => a[0].CompareTo(b[0]));
    result = 0;

    for (int j = 0; j < n; j++)
    {
        if (j == 0)
        {
            result++;
            rank = list[j][1];
            continue;
        }

        if (rank > list[j][1])
        {
            result++;
            rank = list[j][1];
        }
    }
    Console.WriteLine(result);
}
