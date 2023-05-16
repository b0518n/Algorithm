int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
double result = 0.0f;
int max = 0;

for (int i = 0; i < n; i++)
{
    result += input[i];
    if (max < input[i])
    {
        max = input[i];
    }
}

result = ((result / max) * 100) / n;

Console.WriteLine(result);