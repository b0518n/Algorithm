using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int c = 0;
int[] arr = new int[4];
int value = 0;

for (int i = 0; i < t; i++)
{
    c = int.Parse(Console.ReadLine());
    value = c / 25;
    arr[0] = value;
    c = c - (value * 25);
    value = c / 10;
    arr[1] = value;
    c = c - (value * 10);
    value = c / 5;
    arr[2] = value;
    c = c - (value * 5);
    arr[3] = c;

    sb.AppendLine($"{arr[0]} {arr[1]} {arr[2]} {arr[3]}");
}

Console.WriteLine(sb.ToString());