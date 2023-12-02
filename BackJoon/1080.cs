int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

string str = string.Empty;
int[,] arr = new int[n, m];
int result = 0;

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        arr[i, j] = int.Parse(str[j].ToString());
    }
}

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();

    for (int j = 0; j < m; j++)
    {
        if (int.Parse(str[j].ToString()) != arr[i, j])
        {
            arr[i, j] = 1; // 다를 경우
        }
        else
        {
            arr[i, j] = 0; // 같을 경우
        }
    }
}

bool isEqual = true;

if (n < 3 || m < 3)
{

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (arr[i, j] == 1)
            {
                isEqual = false;
            }
        }
    }

    if (!isEqual)
    {
        result = -1;
    }
}
else
{
    for (int i = 0; i < n - 2; i++)
    {
        for (int j = 0; j < m - 2; j++)
        {
            if (arr[i, j] == 0)
            {
                continue;
            }
            else
            {
                for (int k = i; k < i + 3; k++)
                {
                    for (int l = j; l < j + 3; l++)
                    {
                        if (arr[k, l] == 0)
                        {
                            arr[k, l] = 1;
                        }
                        else
                        {
                            arr[k, l] = 0;
                        }
                    }
                }

                result++;
            }
        }
    }

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (arr[i, j] == 1)
            {
                isEqual = false;
            }
        }
    }

    if (!isEqual)
    {
        result = -1;
    }
}

Console.WriteLine(result);