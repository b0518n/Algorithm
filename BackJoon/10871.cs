using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int x = input[1];
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
for (int i = 0; i < n; i++)
{
    if (arr[i] < x)
    {
        sb.Append(arr[i] + " ");
    }
}

Console.WriteLine(sb.ToString());