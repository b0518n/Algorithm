int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int setOfStrings = int.MaxValue;
int line = int.MaxValue;
int result = int.MaxValue;

int mok = 0;
int nmg = 0;

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    setOfStrings = Math.Min(setOfStrings, input[0]);
    line = Math.Min(line, input[1]);
}

if (n <= 6)
{
    result = Math.Min(result, setOfStrings);
    result = Math.Min(result, n * line);
}
else
{
    mok = n / 6;
    nmg = n % 6;

    result = Math.Min(result, (mok + 1) * setOfStrings);
    result = Math.Min(result, (mok * setOfStrings) + (nmg * line));
    result = Math.Min(result, n * line);
}

Console.WriteLine(result);