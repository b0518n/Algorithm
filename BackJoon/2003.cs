int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int[] sequence = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int sum = 0;
int count = 0;

for (int i = 0; i < n; i++)
{
    sum = 0;
    for (int j = i; j < n; j++)
    {
        sum += sequence[j];
        if (sum == m)
        {
            count++;
            break;
        }
    }
}

Console.WriteLine(count);