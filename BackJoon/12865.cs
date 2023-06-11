string str1 = Console.ReadLine();
string str2 = Console.ReadLine();

int count = 0;
int max = 0;
int k = 0;
int previousIndex = 0;
for (int i = 0; i < str1.Length; i++)
{
    count = 0;
    k = 0;
    previousIndex = 0;

    for (int j = i; j < str1.Length; j++)
    {
        while (true)
        {
            if (str1[j] == str2[k])
            {
                count++;
                previousIndex = k;
                k = previousIndex + 1;
                break;
            }

            if (k == str2.Length - 1)
            {
                k = previousIndex + 1;
                break;
            }
            else
            {
                k++;
            }
        }

        if (previousIndex == str2.Length - 1)
        {
            break;
        }
    }

    if (max < count)
    {
        max = count;
    }
}

Console.WriteLine(max);