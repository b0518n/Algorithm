int c = int.Parse(Console.ReadLine());
int[] input = null;
int n = 0;
int sum = 0;
int avg = 0;
int count = 0;

for (int i = 0; i < c; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    sum = input.Sum() - n;
    avg = sum / n;
    for (int j = 1; j < n + 1; j++)
    {
        if (input[j] > avg)
        {
            count++;
        }
    }

    Console.WriteLine(string.Format("{0:F3}", (count / (double)n) * 100) + "%");
    count = 0;
}