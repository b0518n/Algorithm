string[] str2 = { "c=", "c-", "d-", "lj", "nj", "s=", "z=" };
string[] str3 = { "dz=" };
int count = 0;
bool flag = false;

string str = Console.ReadLine();
int i = 0;

while (true)
{
    if (i >= str.Length)
    {
        break;
    }

    if (i <= str.Length - 1 - 2)
    {
        if (str.Substring(i, 3) == str3[0])
        {
            i += 3;
            count++;
            continue;
        }
    }

    flag = false;

    if (i <= str.Length - 1 - 1)
    {
        foreach (string tmp in str2)
        {
            if (str.Substring(i, 2) == tmp)
            {
                flag = true;
                i += 2;
                count++;
                break;
            }
        }
    }

    if (flag == true)
    {
        continue;
    }

    i++;
    count++;
}

Console.WriteLine(count);