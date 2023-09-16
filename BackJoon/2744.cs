string input = Console.ReadLine();
char[] chars = new char[input.Length];

for (int i = 0; i < input.Length; i++)
{
    if (input[i] >= 97)
    {
        chars[i] = (char)(input[i] - 97 + 65);
    }
    else
    {
        chars[i] = (char)(input[i] - 65 + 97);
    }
}

Console.WriteLine(string.Join("", chars));