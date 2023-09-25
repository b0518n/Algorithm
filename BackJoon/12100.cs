int n = int.Parse(Console.ReadLine());
int[] input = null;

int[,] dp = new int[n, n];
int max = 0;
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        dp[i, j] = input[j];
        max = Math.Max(max, dp[i, j]);
    }
}


List<string> list = new List<string>();
Recursion(string.Empty, 0);
for (int i = 0; i < list.Count; i++)
{
    GetLargestBlock(list[i]);
}

Console.WriteLine(max);


// 0 : left, 1 : right, 2 : up 3 : down
void Recursion(string str, int count)
{
    if (count == 5)
    {
        list.Add(str);
        return;
    }

    for (int i = 0; i < 4; i++)
    {
        str += $"{i}";
        Recursion(str, count + 1);
        str = str.Substring(0, str.Length - 1);
    }
}

void GetLargestBlock(string str)
{
    int[,] temp = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            temp[i, j] = dp[i, j];
        }
    }

    for (int i = 0; i < 5; i++)
    {
        switch (int.Parse(str[i].ToString()))
        {
            case 0:
                LeftMergeAndMoveBlack(temp);
                break;
            case 1:
                RightMergeAndMoveBlack(temp);
                break;
            case 2:
                UpMergeAndMoveBlack(temp);
                break;
            case 3:
                DownMergeAndMoveBlack(temp);
                break;
        }
    }

}

void LeftMergeAndMoveBlack(int[,] arr)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (arr[i, j] == 0)
            {
                continue;
            }

            for (int k = j + 1; k < n; k++)
            {
                if (arr[i, k] == 0)
                {
                    if (k == n - 1)
                    {
                        LeftMove(arr, i, j);
                    }
                    continue;
                }

                if (arr[i, j] == arr[i, k])
                {
                    arr[i, j] *= 2;
                    max = Math.Max(max, arr[i, j]);
                    arr[i, k] = 0;
                    if (j == 0)
                    {
                        break;
                    }

                    LeftMove(arr, i, j);
                    break;

                }
                else
                {
                    LeftMove(arr, i, j);
                    break;
                }
            }

            if (j == n - 1)
            {
                LeftMove(arr, i, j);
            }
        }
    }
}

void LeftMove(int[,] arr, int y, int x)
{
    int temp = 0;

    for (int l = x - 1; l >= 0; l--)
    {
        if (arr[y, l] == 0 && l > 0)
        {
            continue;
        }

        if (arr[y, l] != 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[y, l + 1] = temp;
            break;
        }

        if (l == 0 && arr[y, l] == 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[y, l] = temp;
            break;
        }

    }
}

void RightMergeAndMoveBlack(int[,] arr)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = n - 1; j >= 0; j--)
        {
            if (arr[i, j] == 0)
            {
                continue;
            }

            for (int k = j - 1; k >= 0; k--)
            {
                if (arr[i, k] == 0)
                {
                    if (k == 0)
                    {
                        RightMove(arr, i, j);
                    }
                    continue;
                }

                if (arr[i, j] == arr[i, k])
                {
                    arr[i, j] *= 2;
                    max = Math.Max(max, arr[i, j]);
                    arr[i, k] = 0;
                    if (j == 0)
                    {
                        break;
                    }

                    RightMove(arr, i, j);
                    break;

                }
                else
                {
                    RightMove(arr, i, j);
                    break;
                }
            }

            if (j == 0)
            {
                RightMove(arr, i, j);
            }
        }
    }
}

void RightMove(int[,] arr, int y, int x)
{
    int temp = 0;

    for (int l = x + 1; l < n; l++)
    {
        if (arr[y, l] == 0 && l < n - 1)
        {
            continue;
        }

        if (arr[y, l] != 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[y, l - 1] = temp;
            break;
        }

        if (l == n - 1 && arr[y, l] == 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[y, l] = temp;
            break;
        }
    }
}

void UpMergeAndMoveBlack(int[,] arr)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (arr[j, i] == 0)
            {
                continue;
            }

            for (int k = j + 1; k < n; k++)
            {
                if (arr[k, i] == 0)
                {
                    if (k == n - 1)
                    {
                        UpMove(arr, j, i);
                    }
                    continue;
                }

                if (arr[j, i] == arr[k, i])
                {
                    arr[j, i] *= 2;
                    max = Math.Max(max, arr[j, i]);
                    arr[k, i] = 0;
                    if (j == 0)
                    {
                        break;
                    }

                    UpMove(arr, j, i);
                    break;

                }
                else
                {
                    UpMove(arr, j, i);
                    break;
                }
            }

            if (j == n - 1)
            {
                UpMove(arr, j, i);
            }
        }
    }
}

void UpMove(int[,] arr, int y, int x)
{
    int temp = 0;

    for (int l = y - 1; l >= 0; l--)
    {
        if (arr[l, x] == 0 && l > 0)
        {
            continue;
        }

        if (arr[l, x] != 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[l + 1, x] = temp;
            break;
        }

        if (l == 0 && arr[l, x] == 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[l, x] = temp;
            break;
        }
    }
}

void DownMergeAndMoveBlack(int[,] arr)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = n - 1; j >= 0; j--)
        {
            if (arr[j, i] == 0)
            {
                continue;
            }

            for (int k = j - 1; k >= 0; k--)
            {
                if (arr[k, i] == 0)
                {
                    if (k == 0)
                    {
                        DownMove(arr, j, i);
                    }
                    continue;
                }

                if (arr[j, i] == arr[k, i])
                {
                    arr[j, i] *= 2;
                    max = Math.Max(max, arr[j, i]);
                    arr[k, i] = 0;
                    if (j == 0)
                    {
                        break;
                    }

                    DownMove(arr, j, i);
                    break;

                }
                else
                {
                    DownMove(arr, j, i);
                    break;
                }
            }

            if (j == 0)
            {
                DownMove(arr, j, i);
            }
        }
    }
}

void DownMove(int[,] arr, int y, int x)
{
    int temp = 0;

    for (int l = y + 1; l < n; l++)
    {
        if (arr[l, x] == 0 && l < n - 1)
        {
            continue;
        }

        if (arr[l, x] != 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[l - 1, x] = temp;
            break;
        }

        if (l == n - 1 && arr[l, x] == 0)
        {
            temp = arr[y, x];
            arr[y, x] = 0;
            arr[l, x] = temp;
            break;
        }
    }
}