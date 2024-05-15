StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int result = 0;

int[] dotArr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
Array.Sort(dotArr);
for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    result = GetDotCnt(input[0], input[1]);
    sw.WriteLine(result);
}

sw.Flush();
sw.Close();

int GetDotCnt(int min, int max)
{
    int minIndex = GetMinIndex(min);
    int maxIndex = GetMaxIndex(max);

    return maxIndex - minIndex;
}
int GetMinIndex(int value)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (value > dotArr[middle])
        {
            left = middle + 1;
        }
        else
        {
            right = middle - 1;
        }
    }

    return left;
}
int GetMaxIndex(int value)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (value >= dotArr[middle])
        {
            left = middle + 1;
        }
        else
        {
            right = middle - 1;
        }
    }

    return left;
}