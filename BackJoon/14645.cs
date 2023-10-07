int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    k += input[0];
    k -= input[1];
}

Console.WriteLine("비와이");