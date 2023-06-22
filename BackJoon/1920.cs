StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int k = input[0];
int n = input[1];

int value = 0;
int maxValue = 0;

int[] arr = new int[k];
for (int i = 0; i < k; i++)
{
    value = int.Parse(sr.ReadLine());
    arr[i] = value;

    if (i == 0)
    {
        maxValue = value;
    }
    else
    {
        if (maxValue < value)
        {
            maxValue = value;
        }
    }
}

int start = 0;
int end = maxValue;
int mid = 0;
int count = 0;
long max = 0;

while (start <= end)
{
    mid = (start + end) / 2;
    count = 0;

    for (int i = 0; i < k; i++)
    {
        count += (arr[i] / mid);
    }

    if (count < n)
    {
        end = mid - 1;
    }
    else if (count >= n)
    {
        start = mid + 1;
        max = Math.Max(max, mid);
    }
}

sw.Write(max);
sw.Flush();
sw.Close();
sr.Close();