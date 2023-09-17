StringBuilder sb = new StringBuilder();
string input = null;
int[] arr = null;

while (true)
{
    input = Console.ReadLine();
    if (input == null || input == string.Empty)
    {
        break;
    }

    arr = Array.ConvertAll(input.Split(), int.Parse);
    sb.AppendLine((arr[1] / (arr[0] + 1)).ToString());
}

Console.WriteLine(sb.ToString());