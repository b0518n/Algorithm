int n = int.Parse(Console.ReadLine());
int[] input = null;
long s = 0;
long b = 0;
List<int[]> list = new List<int[]>();
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list.Add(new int[2] { input[0], input[1] });
}

int[,] dp = new int[n + 1, 1 << n];
long result = int.MaxValue;
BruteForce(0, 0, 0, 0);
Console.WriteLine(result);

void BruteForce(int ingredientCnt, int foodData, long _s, long _b)
{
    bool isFirst = false;

    if (ingredientCnt == n) return;

    for (int i = 0; i < n; i++)
    {
        if ((foodData & (1 << i)) == 0)
        {
            if (_s == 0 && _b == 0)
            {
                isFirst = true;
                _s = list[i][0];
                _b = list[i][1];
            }
            else
            {
                _s *= list[i][0];
                _b += list[i][1];
            }

            result = Math.Min(result, Math.Abs(_s - _b));
            BruteForce(ingredientCnt + 1, (foodData | (1 << i)), _s, _b);
            if (isFirst)
            {
                _s = 0;
                _b = 0;
            }
            else
            {
                _s /= list[i][0];
                _b -= list[i][1];
            }
        }
    }
}