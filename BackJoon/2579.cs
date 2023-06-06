int n = int.Parse(Console.ReadLine());
int value = 0;
int[] arr = new int[n];
int[] max = new int[n];
for (int i = 0; i < n; i++)
{
    value = int.Parse(Console.ReadLine());
    arr[i] = value;
}

for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        max[i] = arr[i];
    }
    else if (i == 1)
    {
        max[i] = arr[i] + arr[i - 1];
    }
    else if (i == 2)
    {
        max[i] = Math.Max(arr[0] + arr[i], arr[1] + arr[i]);
    }
    else
    {
        max[i] = Math.Max(max[i - 2] + arr[i], max[i - 3] + arr[i - 1] + arr[i]);
    }
}
Console.WriteLine(max[max.Length - 1]);