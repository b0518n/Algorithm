int n = int.Parse(Console.ReadLine());
int[] scores = new int[n];
int input = 0;

for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    scores[i] = input;
}

int value = scores[n - 1];
int result = 0;

for (int i = n - 2; i >= 0; i--)
{
    while (true)
    {
        if (scores[i] >= value)
        {
            result++;
            scores[i]--;
        }
        else
        {
            value = scores[i];
            break;
        }
    }
}

Console.WriteLine(result);