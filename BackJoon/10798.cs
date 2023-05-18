using System.Text;

StringBuilder sb = new StringBuilder();
string input = null;
string[] arr = new string[5];
int maxLength = 0;

for (int i = 0; i < 5; i++)
{
    input = Console.ReadLine();
    arr[i] = input;
    if (maxLength < input.Length)
    {
        maxLength = input.Length;
    }
}

for (int i = 0; i < maxLength; i++)
{
    if (i <= arr[0].Length - 1)
    {
        sb.Append(arr[0][i]);
    }

    if (i <= arr[1].Length - 1)
    {
        sb.Append(arr[1][i]);
    }

    if (i <= arr[2].Length - 1)
    {
        sb.Append(arr[2][i]);
    }

    if (i <= arr[3].Length - 1)
    {
        sb.Append(arr[3][i]);
    }

    if (i <= arr[4].Length - 1)
    {
        sb.Append(arr[4][i]);
    }
}

Console.WriteLine(sb.ToString());