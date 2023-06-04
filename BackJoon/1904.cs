int n = int.Parse(Console.ReadLine());
int[] arr = new int[1000001];
arr[1] = 1;
arr[2] = 2;

for (int i = 3; i <= arr.Length - 1; i++)
{
    arr[i] = (arr[i - 1] % 15746) + (arr[i - 2] % 15746);
}

Console.WriteLine(arr[n] % 15746);