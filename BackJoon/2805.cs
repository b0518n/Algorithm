StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

long[] trees = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

long start = 0;
long end = trees.Max();
long max = 0;

while (start <= end)
{
    long mid = (start + end) / 2;
    long value = 0;
    for (int i = 0; i < trees.Length; i++)
    {
        if (trees[i] > mid)
        {
            value += trees[i] - mid;
        }
    }

    if (value >= m)
    {
        start = mid + 1;
        max = Math.Max(max, mid);
    }
    else
    {
        end = mid - 1;
    }
}


sw.WriteLine(max);
sw.Flush();
sw.Close();
sr.Close();