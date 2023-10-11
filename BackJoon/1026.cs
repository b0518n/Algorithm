int n = int.Parse(Console.ReadLine());
int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] b = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

Array.Sort(a);
Array.Reverse(a);
Array.Sort(b);

int result = 0;

for (int i = 0; i < n; i++)
{
    result += a[i] * b[i];
}

Console.WriteLine(result);