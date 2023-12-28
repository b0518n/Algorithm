string input = Console.ReadLine();
int length = input.Length;
int index = 0;
char[] arr = { 'U', 'C', 'P', 'C' };

for (int i = 0; i < length; i++)
{
    if (index == 4)
    {
        Console.WriteLine("I love UCPC");
        break;
    }

    if (arr[index] == input[i])
    {
        index++;
    }

    if (i == length - 1)
    {
        if (index == 4)
        {
            Console.WriteLine("I love UCPC");
            break;
        }

        Console.WriteLine("I hate UCPC");
    }
}