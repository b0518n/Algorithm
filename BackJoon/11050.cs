int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int numerator = 1;
int denominator = 1;

for (int i = n; i > n - k; i--)
{
    numerator *= i;
}

for (int i = k; i >= 1; i--)
{
    denominator *= i;
}

int result = numerator / denominator;
Console.WriteLine(result);