int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[] values = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int difference = m;

for (int i = 0; i < n - 2; i++)
{
    for (int j = i + 1; j < n - 1; j++)
    {
        for (int k = j + 1; k < n; k++)
        {
            int tmp = m - (values[i] + values[j] + values[k]);

            if (tmp < 0)
            {
                continue;
            }

            if (difference > tmp)
            {
                difference = tmp;
            }
        }
    }
}

Console.WriteLine(m - difference);