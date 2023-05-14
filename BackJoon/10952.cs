using System.Text;

StringBuilder sb = new StringBuilder();
int[] input = null;
int a = 0;
int b = 0;

while (true)
{
    string input = console.Readline().split();
    if (input == null)
    {
        break;
    }
    else
    {
        int[] tmp = Array.ConvertAll(input.split(), int.Parse);
        a = tmp[0];
        b = tmp[1];
        sb.AppendLine($"{a + b}");
    }
}

Console.WriteLine(sb.ToString());