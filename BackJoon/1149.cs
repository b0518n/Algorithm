int n = int.Parse(Console.ReadLine());
int[] arr = null;
int[] input = null;
int min = 1000001;
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    if (i == 0)
    {
        arr = input;
    }
    else
    {
        for (int j = 0; j < input.Length; j++)
        {
            min = 1000001;
            for (int k = 0; k < input.Length; k++)
            {
                if (j == k)
                {
                    continue;
                }

                if (min > arr[k])
                {
                    min = arr[k];
                }
            }

            input[j] += min;
        }
    }

    arr = input;
}

Console.WriteLine(arr.Min());