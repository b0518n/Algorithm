int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int firstIndex = 0;
int secondIndex = 0;

int[] arr = new int[n + 1];
for (int i = 0; i < n + 1; i++)
{
    arr[i] = i;
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    firstIndex = input[0];
    secondIndex = input[1];

    if (firstIndex == secondIndex)
    {
        continue;
    }
    else
    {
        Array.Reverse(arr, firstIndex, secondIndex - firstIndex + 1);
    }
}

for (int i = 1; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}