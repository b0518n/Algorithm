string input = Console.ReadLine();

char[] arr = new char[input.Length];

for (int i = 0; i < input.Length; i++)
{
    arr[i] = (char)(input[i] - 97 + 65);
}

Console.WriteLine(string.Join("", arr));