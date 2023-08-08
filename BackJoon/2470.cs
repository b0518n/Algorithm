StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Array.Sort(arr);

int start = 0;
int end = arr.Length - 1;
int value = 0;
int min = int.MaxValue;
int resultLeft = 0;
int resultRight = 0;

while (true)
{
    if (start >= end)
    {
        break;
    }

    value = arr[start] + arr[end];
    int absValue = Math.Abs(value);

    if (min > absValue)
    {
        min = absValue;
        resultLeft = arr[start];
        resultRight = arr[end];
    }

    if (value > 0)
    {
        end--;
    }
    else if (value < 0)
    {
        start++;
    }
    else
    {
        break;
    }
}


sw.Write(resultLeft + " " + resultRight);
sw.Flush();
sw.Close();