StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));
int t = int.Parse(Console.ReadLine());

int x1 = 0;
int y1 = 0;
int r1 = 0;

int x2 = 0;
int y2 = 0;
int r2 = 0;

for (int i = 0; i < t; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

    // 원 1
    x1 = input[0];
    y1 = input[1];
    r1 = input[2];

    // 원 2
    x2 = input[3];
    y2 = input[4];
    r2 = input[5];

    double d = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

    if (x1 != x2 || y1 != y2)
    {
        // 있을 수 있는 위치가 2곳인 경우 (원과 원이 만나는 점이 2개 일 때)
        if (Math.Abs(r1 - r2) < d && d < r1 + r2)
        {
            sw.WriteLine(2);
        }
        else if (r1 + r2 == d || Math.Abs(r1 - r2) == d) // 있을 수 있는 위치가 1곳 인 경우 (내접과, 외접)
        {
            sw.WriteLine(1);
        }
        else if (r1 + r2 < d || Math.Abs(r1 - r2) > d)// 있을 수 있는 위치가 없는 경우 (두 원이 만나지 않는 경우)
        {
            sw.WriteLine(0);
        }
    }
    else
    {
        if (r1 == r2) // 있을 수 있는 위치가 무한 대인 경우 (두 원의 중심이 같으면서, 넓이가 동일한 경우)
        {
            sw.WriteLine(-1);
        }
        else // 있을 수 있는 위치가 없는 경우 (두 원의 중심이 같지만, 넓이가 다른 경우)
        {
            sw.WriteLine(0);
        }
    }
}
sw.Close();
