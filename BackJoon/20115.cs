StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] drinks = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
double result = 0.0f;
int max = 0;

for (int i = 0; i < n; i++)
{
    if (max == 0)
    {
        max = drinks[i];
    }
    else
    {
        max = Math.Max(max, drinks[i]);
    }
}

for (int i = 0; i < n; i++)
{
    if (max == drinks[i])
    {
        result += max;
    }
    else
    {
        result += (double)drinks[i] / 2;
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();