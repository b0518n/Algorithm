int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int v = int.Parse(Console.ReadLine());
int result = 0;

for (int i = 0; i < n; i++)
{
    if (arr[i] == v)
    {
        result++;
    }
}

Console.WriteLine(result);