// a : 97 A : 65
int[] arr = new int[26];
string str = Console.ReadLine();
int index = 0;
int max = 0;
bool flag = false;

for (int i = 0; i < str.Length; i++)
{
    if ((int)str[i] < 97)
    {
        arr[(int)str[i] - 65]++;
        if (max < arr[(int)str[i] - 65])
        {
            max = arr[(int)str[i] - 65];
            index = (int)str[i] - 65;
        }
    }
    else
    {
        arr[(int)str[i] - 97]++;
        if (max < arr[(int)str[i] - 97])
        {
            max = arr[(int)str[i] - 97];
            index = (int)str[i] - 97;
        }
    }
}

for (int i = 0; i < 26; i++)
{
    if (arr[i] == max && index != i)
    {
        flag = true;
        break;
    }
}

if (flag == true)
{
    Console.WriteLine("?");
}
else
{
    Console.WriteLine((char)(index + 65));
}