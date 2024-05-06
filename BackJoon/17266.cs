StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

int[] arr = null;
int x = 0;

int result = 0;

if (m == 1)
{
    x = int.Parse(Console.ReadLine());
    GetMinLampHeight();
}
else
{
    arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    GetMinLampHeight();
}

Print();

void GetMinLampHeight()
{
    if (arr == null)
    {
        result = Math.Max(n - x, x - 0);
        return;
    }
    else
    {
        int left = 0;
        int right = n;
        int middle = 0;

        while (left <= right)
        {
            middle = (left + right) / 2;
            if (CanMove(middle))
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        result = left;
        return;
    }
}
bool CanMove(int height)
{
    int minPosition = 0;
    int maxPosition = 0;

    int temp = 0;

    for (int i = 0; i < m; i++)
    {
        if (i == 0)
        {
            temp = arr[i] - height;
            if (temp <= 0)
            {
                minPosition = 0;
                maxPosition = arr[i] + height;
            }
            else
            {
                return false;
            }
        }
        else if (i == m - 1)
        {
            temp = arr[i] - height;
            if (temp <= maxPosition && arr[i] + height >= n)
            {
                maxPosition = n;
            }
            else
            {
                return false;
            }
        }
        else
        {
            temp = arr[i] - height;
            if (temp <= maxPosition)
            {
                minPosition = temp;
                maxPosition = arr[i] + height;
            }
            else
            {
                return false;
            }
        }
    }

    return true;
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}