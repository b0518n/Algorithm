int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int result = 0;

int min = k * (k + 1) / 2;


if (n < min)
{
    result = -1;
}
else
{
    int value = n - min;
    if (value % k == 0)
    {
        result = k - 1;
    }
    else
    {
        result = k;
    }
}

Console.WriteLine(result);