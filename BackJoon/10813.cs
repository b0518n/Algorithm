int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int n = input[0];
int m = input[1];
int tmp = 0;

int[] arr = new int[n + 1];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = i;
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    tmp = arr[input[0]];
    arr[input[0]] = arr[input[1]];
    arr[input[1]] = tmp;
}

for (int i = 1; i < n + 1; i++)
{
    Console.Write(arr[i] + " ");
}