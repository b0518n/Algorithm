int[] arr = new int[31];
arr[0] = -1;
int n = 0;
int count = 0;

for (int i = 0; i < 28; i++)
{
    n = int.Parse(Console.ReadLine());
    if (arr[n] == 0)
    {
        arr[n] = -1;
    }
}

for (int j = 0; j < arr.Length; j++)
{
    if (arr[j] == 0)
    {
        count++;
        Console.WriteLine(j);

        if (count == 2)
        {
            break;
        }
    }
}