int n = int.Parse(Console.ReadLine());
int[] arr = new int[n + 1];
int[] result = new int[n + 1];
int input = 0;
int max = 0;

for (int i = 1; i <= n; i++)
{
    input = int.Parse(Console.ReadLine());
    arr[i] = input;

    if (i == 1)
    {
        result[i] = arr[i];
        max = result[i];
    }
    else if (i == 2)
    {
        result[i] = arr[i - 1] + arr[i];
    }
    else if (i == 3)
    {
        result[i] = Math.Max(arr[i - 2] + arr[i], arr[i - 1] + arr[i]);
    }
    else
    {
        result[i] = Math.Max(Math.Max(result[i - 2] + arr[i], result[i - 3] + arr[i - 1] + arr[i]), result[i - 1]);
    }

    if (max < result[i])
    {
        max = result[i];
    }
}

Console.WriteLine(max);