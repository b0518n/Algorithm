StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());

int[,] arr1 = new int[n, n];
int[,] arr2 = new int[n, n];
int[] input = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        arr1[i, j] = input[j];
        if (input[j] == 0)
        {
            arr2[i, j] = 0;
        }
        else
        {
            arr2[i, j] = 1;
        }
    }
}

bool isMinDist = true;

for (int i = 0; i < n; i++) // 중간
{
    if (!isMinDist)
        break;

    for (int j = 0; j < n; j++) // 시작
    {
        if (!isMinDist)
            break;
        if (i == j)
            continue;

        for (int k = 0; k < n; k++) // 끝
        {
            if (i == k)
                continue;

            if (arr1[j, k] == arr1[j, i] + arr1[i, k])
            {
                arr2[j, k] = 0;
            }
            else if (arr1[j, k] > arr1[j, i] + arr1[i, k])
            {
                isMinDist = false;
                break;
            }
        }
    }
}

int result = 0;

if (!isMinDist)
{
    result = -1;
    sw.WriteLine(result);
}
else
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (arr2[i, j] == 0)
                continue;

            result += arr1[i, j];
        }
    }

    sw.WriteLine(result / 2);
}

sw.Flush();
sw.Close();