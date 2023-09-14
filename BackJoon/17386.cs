int[] input = null;
List<int[]> dots = new List<int[]>();


for (int i = 0; i < 2; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    dots.Add(new int[2] { input[0], input[1] });
    dots.Add(new int[2] { input[2], input[3] });

}

int value1 = CCW(dots[0][0], dots[0][1], dots[1][0], dots[1][1], dots[2][0], dots[2][1]);
int value2 = CCW(dots[0][0], dots[0][1], dots[1][0], dots[1][1], dots[3][0], dots[3][1]);
int value3 = CCW(dots[2][0], dots[2][1], dots[3][0], dots[3][1], dots[0][0], dots[0][1]);
int value4 = CCW(dots[2][0], dots[2][1], dots[3][0], dots[3][1], dots[1][0], dots[1][1]);

if (value1 * value2 < 0 && value3 * value4 < 0)
{
    Console.WriteLine(1);
}
else
{
    Console.WriteLine(0);
}

int CCW(long x1, long y1, long x2, long y2, long x3, long y3)
{
    return (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2) > 0 ? 1 : -1);
}