int n = int.Parse(Console.ReadLine());
int w = int.Parse(Console.ReadLine());
int[] input = null;

List<int[]> list = new List<int[]>();
list.Add(new int[2] { 1, 1 });
for (int i = 0; i < w; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list.Add(new int[2] { input[0], input[1] });
}

int[,] dp = new int[w + 1, w + 1];
int[,] _dp = new int[w + 1, w + 1];
Console.WriteLine(Move(0, 0));
GetSequence(0, 0);

int Move(int x, int y)
{
    if (x == w || y == w)
    {
        return 0;
    }

    if (dp[x, y] != 0)
    {
        return dp[x, y];
    }

    int destination = Math.Max(x, y) + 1;
    int ret1 = Move(destination, y) + Distance(list[x][0], list[x][1], list[destination][0], list[destination][1]);
    int ret2 = Move(x, destination) + Distance((y == 0 ? n : list[y][0]), (y == 0 ? n : list[y][1]), list[destination][0], list[destination][1]);

    if (ret1 > ret2)
    {
        _dp[x, y] = 2;
        dp[x, y] = ret2;
    }
    else
    {
        _dp[x, y] = 1;
        dp[x, y] = ret1;
    }

    return dp[x, y];
}

void GetSequence(int x, int y)
{
    int _x = x;
    int _y = y;
    int destination = 1;

    while (true)
    {
        if (_x == w || _y == w)
        {
            break;
        }

        if (_dp[_x, _y] == 1)
        {
            Console.WriteLine(1);
            _x = destination;
            destination++;
        }
        else
        {
            Console.WriteLine(2);
            _y = destination;
            destination++;
        }
    }
}

int Distance(int x1, int y1, int x2, int y2)
{
    return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
}