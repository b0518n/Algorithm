int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int i = 0;
int j = 0;
int k = 0;

int[] arr = new int[n + 1];
for (int x = 0; x < m; x++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    i = input[0];
    j = input[1];
    k = input[2];

    for (int y = i; y <= j; y++)
    {
        arr[y] = k;
    }
}

for (int x = 1; x < n + 1; x++)
{
    Console.Write(arr[x] + " ");
}
