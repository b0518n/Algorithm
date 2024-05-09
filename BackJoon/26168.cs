StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
string[] input = sr.ReadLine().Split();
int n = int.Parse(input[0]);
int m = int.Parse(input[1]);

long[] arr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
Array.Sort(arr);
for (int i = 0; i < m; i++)
{
    input = sr.ReadLine().Split();
    if (int.Parse(input[0]) == 1)
    {
        Question_1(long.Parse(input[1]));
    }
    else if (int.Parse(input[0]) == 2)
    {
        Question_2(long.Parse(input[1]));
    }
    else
    {
        Question_3(long.Parse(input[1]), long.Parse(input[2]));
    }
}

sw.Flush();
sw.Close();

void Question_1(long value)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (arr[middle] >= value)
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    sw.WriteLine(n - left);
}
void Question_2(long value)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (arr[middle] > value)
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    sw.WriteLine(n - left);
}
void Question_3(long value1, long value2)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    int minIndex = 0;
    int maxIndex = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (arr[middle] >= value1)
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    minIndex = left;

    left = 0;
    right = n - 1;
    middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (arr[middle] > value2)
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    maxIndex = left;
    sw.WriteLine(maxIndex - minIndex);

}