int[] arr = new int[26];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = -1;
}

int result = 0;
int n = int.Parse(Console.ReadLine());
string str = null;
for (int i = 0; i < n; i++)
{
    int[] arr1 = (int[])arr.Clone();
    bool flag = false;
    str = Console.ReadLine();
    for (int j = 0; j < str.Length; j++)
    {
        if (arr1[(int)str[j] - 97] == -1)
        {
            arr1[(int)str[j] - 97] = j;
        }
        else
        {
            if (j - arr1[(int)str[j] - 97] == 1)
            {
                arr1[(int)str[j] - 97] = j;
            }
            else
            {
                flag = true;
                break;
            }
        }
    }

    if (flag == false)
    {
        result++;
    }
}

Console.WriteLine(result);