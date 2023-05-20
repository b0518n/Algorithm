int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int count = 0;

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == 2)
    {
        count++;
        continue;
    }

    for (int j = 2; j < input[i]; j++)
    {
        if (input[i] % j == 0)
        {
            break;
        }

        if (j == input[i] - 1)
        {
            count++;
        }
    }
}

Console.WriteLine(count);