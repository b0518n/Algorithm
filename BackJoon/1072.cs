StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int x = input[0];
int y = input[1];
long z = ((long)y * 100) / x;

BinarySearch();
sw.Flush();
sw.Close();

void BinarySearch()
{
    if (z >= 99)
    {
        sw.WriteLine(-1);
        return;
    }

    int left = 0;
    int right = 1000000000;
    int middle = 0;

    long temp = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        temp = (((long)y + middle) * 100) / (x + middle);
        if (temp > z)
        {
            right = middle - 1;
        }
        else if (temp == z)
        {
            left = middle + 1;
        }
    }

    sw.WriteLine(left);
    return;
}