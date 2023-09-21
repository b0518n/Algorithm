int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int s = input[1];

int[] sequence = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int count = 0;

Recursion(sequence, -1, 0);
Console.WriteLine(count);

void Recursion(int[] sequence, int index, int sum)
{
    if (sum == s && index != -1)
    {
        count++;
    }

    for (int i = index + 1; i < n; i++)
    {
        sum += sequence[i];
        Recursion(sequence, i, sum);
        sum -= sequence[i];
    }
}