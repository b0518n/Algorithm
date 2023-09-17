StringBuilder sb = new StringBuilder();
int[] input = null;
int a = 0;
int b = 0;

while (true)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];

    if (a == 0 && b == 0)
    {
        break;
    }

    sb.AppendLine(CompareValue(a, b));
}

Console.WriteLine(sb.ToString());

string CompareValue(int a, int b)
{
    return a > b ? "Yes" : "No";
}