string input = null;
string[] strArr = null;
int n = -1;
int m = -1;

List<int> a = null;
List<int> b = null;

bool shouldTerminate = false;

while (true)
{
    if (!shouldTerminate)
    {
        Input();
    }

    if (shouldTerminate)
    {
        break;
    }
}

void Input()
{
    input = Console.ReadLine();
    strArr = input.Split();
    n = int.Parse(strArr[0]);
    m = int.Parse(strArr[1]);

    if (n == 0 && m == 0)
    {
        shouldTerminate = true;
        return;
    }

    a = new List<int>();
    b = new List<int>();

    for (int i = 0; i < n; i++)
    {
        a.Add(int.Parse(Console.ReadLine()));
    }

    for (int i = 0; i < m; i++)
    {
        b.Add(int.Parse(Console.ReadLine()));
    }

    BinarySearch();
}
void BinarySearch()
{
    int result = 0;
    int left = 0;
    int right = m - 1;
    int mid = (left + right) / 2;

    for (int i = 0; i < n; i++)
    {
        left = 0;
        right = m - 1;
        mid = (left + right) / 2;

        while (left <= right)
        {
            if (b[mid] == a[i])
            {
                result++;
                break;
            }
            else if (b[mid] > a[i])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }

            mid = (left + right) / 2;
        }
    }

    Console.WriteLine(result);
}