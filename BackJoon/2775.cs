int t = int.Parse(Console.ReadLine());
int[] arr = new int[210];

for (int i = 0; i < arr.Length; i++)
{
    if (i >= 0 && i <= 13)
    {
        arr[i] = i + 1;
    }
    else
    {
        if (i % 14 == 0)
        {
            arr[i] = 1;
        }
        else
        {
            arr[i] = arr[i - 1] + arr[i - 14];
        }
    }
}

for (int i = 0; i < t; i++)
{
    int k = int.Parse(Console.ReadLine());
    int n = int.Parse(Console.ReadLine());

    Console.WriteLine(arr[(k * 14) + (n - 1)]);
}