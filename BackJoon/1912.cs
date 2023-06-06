int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int max = 0;
int sum = 0;
for (int i = input.Length - 1; i >= 0; i--)
{
    if (i == input.Length - 1)
    {
        max = input[i];
    }

    sum += input[i];
    if (sum < 0)
    {
        if (max < sum)
        {
            max = sum;
        }

        sum = 0;
    }
    else
    {
        if (max < sum)
        {
            max = sum;
        }
    }
}

Console.WriteLine(max);