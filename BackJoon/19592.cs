StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
string[] input = null;
int n = 0;
int x = 0;
int y = 0;

int v = 0;
int maxSpeed = 0;
double minTime = -1;
int result = 0;

for (int i = 0; i < t; i++)
{
    input = Console.ReadLine().Split();
    n = int.Parse(input[0]); // The number of participants
    x = int.Parse(input[1]); // x meter
    y = int.Parse(input[2]); // y m/s (한계치)

    input = Console.ReadLine().Split();
    for (int j = 0; j < n - 1; j++)
    {
        v = int.Parse(input[j]);
        if (j == 0)
        {
            minTime = (double)x / v;
            maxSpeed = v;
        }
        else
        {
            minTime = Math.Min(minTime, (double)x / v);
            maxSpeed = Math.Max(maxSpeed, v);
        }
    }

    result = BinarySearch(int.Parse(input[n - 1]));
    sw.WriteLine(result);
}

sw.Flush();
sw.Close();

int BinarySearch(int speed)
{
    if (maxSpeed < speed)
    {
        return 0;
    }
    else if (GetTime(speed, y) >= minTime)
    {
        return -1;
    }

    int left = 0;
    int right = y;
    int mid = -1;

    double time = 0;

    while (left <= right)
    {
        mid = (left + right) / 2;
        time = GetTime(speed, mid);

        if (minTime <= time)
        {
            left = mid + 1;
        }
        else
        {
            right = mid - 1;
        }
    }

    return left;
}
double GetTime(int speed, int boostSpeed)
{
    int distance = x - boostSpeed;
    return ((double)distance / speed) + 1;
}