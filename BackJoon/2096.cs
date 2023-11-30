int n = int.Parse(Console.ReadLine());
int[] input = null;

int fMin = 0;
int fMax = 0;
int sMin = 0;
int sMax = 0;
int tMin = 0;
int tMax = 0;

int _fMin = 0;
int _fMax = 0;
int _sMin = 0;
int _sMax = 0;
int _tMin = 0;
int _tMax = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    if (i == 0)
    {
        fMin = input[0];
        fMax = input[0];
        sMin = input[1];
        sMax = input[1];
        tMin = input[2];
        tMax = input[2];
    }
    else
    {
        _fMin = input[0] + Math.Min(fMin, sMin);
        _fMax = input[0] + Math.Max(fMax, sMax);
        _sMin = input[1] + Math.Min(Math.Min(fMin, sMin), tMin);
        _sMax = input[1] + Math.Max(Math.Max(fMax, sMax), tMax);
        _tMin = input[2] + Math.Min(sMin, tMin);
        _tMax = input[2] + Math.Max(sMax, tMax);

        fMin = _fMin;
        fMax = _fMax;
        sMin = _sMin;
        sMax = _sMax;
        tMin = _tMin;
        tMax = _tMax;
    }
}

int max = Math.Max(Math.Max(fMax, sMax), tMax);
int min = Math.Min(Math.Min(fMin, sMin), tMin);

Console.WriteLine($"{max} {min}");