int n = int.Parse(Console.ReadLine());
string str = Console.ReadLine();
int result = 0;

for (int i = 0; i < str.Length; i++)
{
    if (CheckVowel(str[i]))
    {
        result++;
    }
}

Console.WriteLine(result);

bool CheckVowel(char _char)
{
    bool result = false;

    switch (_char)
    {
        case 'a':
            result = true;
            break;
        case 'i':
            result = true;
            break;
        case 'u':
            result = true;
            break;
        case 'e':
            result = true;
            break;
        case 'o':
            result = true;
            break;
    }

    return result;
}