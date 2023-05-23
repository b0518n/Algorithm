using System.Text;

StringBuilder sb = new StringBuilder();
int n = int.Parse(Console.ReadLine());
int[][] arr = new int[n][];
int[] input = null;
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    arr[i] = input;
}

Array.Sort(arr, (x, y) =>
{
    int compare = x[0].CompareTo(y[0]);

    if (compare == 0)
    {
        compare = x[1].CompareTo(y[1]);
    }

    return compare;
});

for (int i = 0; i < n; i++)
{
    sb.AppendLine($"{arr[i][0]} {arr[i][1]}");
}

Console.WriteLine(sb.ToString());