StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

long n = long.Parse(sr.ReadLine());
long result = 0;
for (int i = 63; i >= 0; i--)
{
    if ((n & (long)1 << i) != 0)
    {
        result += Pow(i);
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

long Pow(int r)
{
    long retValue = 1;

    for (int i = 0; i < r; i++)
    {
        retValue *= 3;
    }

    return retValue;
}