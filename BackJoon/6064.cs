int n = int.Parse(Console.ReadLine());
int[] input = null;
int M = 0;
int N = 0;
int x = 0;
int y = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    M = input[0];
    N = input[1];
    x = input[2];
    y = input[3];

    SearchMonth(M, N, x, y);
}

void SearchMonth(int _m, int _n, int _x, int _y)
{
    int value = 1;
    int x = 1;
    int y = 1;

    while (true)
    {
        if (x == _x && y == _y)
        {
            Console.WriteLine(value);
            return;
        }

        if (x == _m && y == _n)
        {
            Console.WriteLine(-1);
            return;
        }

        if (_x > x && _y > y && _x - x == _y - y)
        {
            value += _x - x;
            x = _x;
            y = _y;
        }
        else
        {
            if (M - x > N - y)
            {
                if (x + N - y == _m)
                {
                    x = _m;
                    y = _n;
                    continue;
                }

                value += N - y + 1;
                x += N - y + 1;
                y = 1;
            }
            else
            {
                if (y + M - x == _n)
                {
                    x = _m;
                    y = _n;
                    continue;
                }

                value += M - x + 1;
                y += M - x + 1;
                x = 1;
            }
        }
    }
}