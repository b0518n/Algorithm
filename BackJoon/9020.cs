int t = int.Parse(Console.ReadLine());
List<bool> arr = new List<bool>();
bool flag = false;
int index = 0;

for (int i = 0; i < t; i++)
{
    int n = int.Parse(Console.ReadLine());

    arr.Add(false);
    arr.Add(false);

    for (int j = 2; j <= n + 1; j++)
    {
        if (j == 2 || j == 3)
        {
            arr.Add(true);
        }
        else
        {
            for (int k = 2; k <= MathF.Sqrt(j); k++)
            {
                if (j % k == 0)
                {
                    flag = true;
                    break;
                }
            }

            if (flag == true)
            {
                flag = false;
                arr.Add(false);
            }
            else
            {
                arr.Add(true);
            }
        }
    }

    while (true)
    {
        int tmp = n / 2;
        if (arr[tmp + index] == true)
        {
            if (arr[n - (tmp + index)] == true)
            {
                Console.WriteLine((tmp - index) + " " + (tmp + index));
                index = 0;
                arr.Clear();
                break;
            }
            else
            {
                index += 1;
            }

        }
        else
        {
            index += 1;
        }
    }

    index = 0;

}


