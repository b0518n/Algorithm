using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int[] input = null;
int a = 0;
int b = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    sb.AppendLine($"Case #{i + 1}: {a} + {b} = {a + b}");
}

Console.WriteLine(sb.ToString());