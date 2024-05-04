StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());

int n = 0;
int[] arr1 = null;
int m = 0;
int[] arr2 = null;

for (int i = 0; i < t; i++)
{
    Input();
    if (n != 1)
    {
        Array.Sort(arr1);
    }
    for (int j = 0; j < m; j++)
    {
        if (IsSeen(arr2[j]))
        {
            sw.WriteLine(1);
        }
        else
        {
            sw.WriteLine(0);
        }
    }
}

sw.Flush();
sw.Close();

void Input()
{
    n = int.Parse(Console.ReadLine());
    if (n == 1)
    {
        arr1 = new int[1] { int.Parse(Console.ReadLine()) };
    }
    else
    {
        arr1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    }

    m = int.Parse(Console.ReadLine());
    if (m == 1)
    {
        arr2 = new int[1] { int.Parse(Console.ReadLine()) };
    }
    else
    {
        arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    }
}
bool IsSeen(int value)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (arr1[middle] == value)
        {
            return true;
        }
        else if (arr1[middle] > value)
        {
            right = middle - 1;
        }
        else
        {
            left = middle + 1;
        }
    }

    return false;
}