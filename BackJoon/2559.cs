int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] sum = new int[n - k + 1];

int tmp = 0;
for (int i = 0; i < sum.Length; i++)
{
    tmp = 0;
    for (int j = i; j < i + k; j++)
    {
        tmp += arr[j];
    }

    sum[i] = tmp;
}

Console.WriteLine(sum.Max());