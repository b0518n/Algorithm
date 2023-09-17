string str1 = Console.ReadLine();
string str2 = Console.ReadLine();

char[] arr1 = new char[1000];
char[] arr2 = new char[1000];

for (int i = 0; i < str1.Length - 1; i++)
{
    arr1[i] = str1[i];
}

for (int i = 0; i < str2.Length - 1; i++)
{
    arr2[i] = str2[i];
}

for (int i = 0; i < arr2.Length; i++)
{
    if (arr1[i] == arr2[i] && arr1[i] == 0)
    {
        Console.WriteLine("go");
        break;
    }
    else if (arr1[i] == arr2[i] && arr1[i] == 'a')
    {
        continue;
    }
    else if (arr1[i] != arr2[i] && arr1[i] == 0)
    {
        Console.WriteLine("no");
        break;
    }
    else if (arr1[i] != arr2[i] && arr2[i] == 0)
    {
        Console.WriteLine("go");
        break;
    }
}