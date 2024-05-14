StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int l = input[1];
int w = input[2];
int h = input[3];

BinarySearch();
sw.Flush();
sw.Close();

void BinarySearch()
{
    double left = 0;
    double right = Math.Min(Math.Min(l, w), h);
    double middle = 0;

    long cnt = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;

        cnt = (long)Math.Floor(l / middle);
        cnt *= (long)Math.Floor(w / middle);
        cnt *= (long)Math.Floor(h / middle);

        if (cnt >= n)
        {
            if (left == middle)
            {
                break;
            }
            left = middle;
        }
        else
        {
            if (right == middle)
            {
                break;
            }
            right = middle;
        }

    }

    sw.WriteLine(left);
}