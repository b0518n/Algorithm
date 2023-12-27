using System.Text;

int t = int.Parse(Console.ReadLine());
int n = 0;
int[] arr = null;
int[] _arr = null;
int rightIndex = -1;
int leftIndex = 1;
int min = -1;
int max = -1;
StringBuilder sb = new StringBuilder();

for (int i = 0; i < t; i++)
{
    n = int.Parse(Console.ReadLine());
    arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    _arr = new int[n];
    Array.Sort(arr);
    _arr[0] = arr[0];
    rightIndex = n - 1;
    leftIndex = 1;

    for (int j = 1; j < n; j += 2)
    {
        if (rightIndex < leftIndex)
        {
            break;
        }
        else if (rightIndex == leftIndex)
        {
            _arr[rightIndex] = arr[j];
            break;
        }

        _arr[rightIndex] = arr[j];
        _arr[leftIndex] = arr[j + 1];
        rightIndex -= 1;
        leftIndex += 1;
    }

    for (int j = 0; j < n; j++)
    {
        if (j == 0)
        {
            max = Math.Abs(_arr[n - 1] - _arr[j]);
        }
        else
        {
            max = Math.Max(max, Math.Abs(_arr[j] - _arr[j - 1]));
        }
    }

    if (min == -1)
    {
        min = max;
        max = -1;
    }
    else
    {
        min = Math.Min(min, max);
        max = -1;
    }

    sb.AppendLine(min.ToString());
    min = -1;
}

Console.WriteLine(sb.ToString());