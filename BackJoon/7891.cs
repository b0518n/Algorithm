int n = int.Parse(Console.ReadLine());
int[] input = null;

StringBuilder sb = new StringBuilder();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    sb.AppendLine((input[0] + input[1]).ToString());
}

Console.WriteLine(sb.ToString());