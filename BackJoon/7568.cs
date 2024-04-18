StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
int n = int.Parse(Console.ReadLine());
int[,] arr = new int[n, 2];
int[] rank = new int[n];
for (int i = 0; i < n; i++)
{
    rank[i] = 1;
}
for (int i = 0; i < n; i++)
{
    int[] tmp = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
    arr[i, 0] = tmp[0];
    arr[i, 1] = tmp[1];
}

for (int i = 0; i < n; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        if (arr[i, 0] > arr[j, 0] && arr[i, 1] > arr[j, 1])
        {
            rank[j] += 1;
        }
        else if (arr[i, 0] < arr[j, 0] && arr[i, 1] < arr[j, 1])
        {
            rank[i] += 1;
        }
    }
}

foreach (int i in rank)
{
    sw.Write(i + " ");
}

sw.Close();

