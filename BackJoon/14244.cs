StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int leafCnt = 0;

for (int i = 1; i < n; i++)
{
    if (m > leafCnt)
    {
        sw.WriteLine($"0 {i}");
        leafCnt++;
    }
    else
    {
        sw.WriteLine($"{i - 1} {i}");
    }
}

sw.Flush();
sw.Close();