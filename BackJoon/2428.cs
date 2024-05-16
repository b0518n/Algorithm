StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] files = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
Array.Sort(files);
long result = 0;

for (int i = 0; i < n; i++)
{
    result += GetShouldCheckFile(i);
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

int GetShouldCheckFile(int index)
{
    int left = index;
    int right = n - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (files[index] * 10 >= 9 * files[middle])
        {
            left = middle + 1;
        }
        else
        {
            right = middle - 1;
        }
    }

    return left - 1 - index;
}