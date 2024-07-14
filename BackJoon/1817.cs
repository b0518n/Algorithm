StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int result = 0;
int nmgboxWeight = m;
if (n != 0)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

    for (int i = 0; i < n; i++)
    {
        if (nmgboxWeight < input[i])
        {
            result++;
            nmgboxWeight = m - input[i];
        }
        else
        {
            nmgboxWeight -= input[i];
        }

        if (i == n - 1)
        {
            result++;
        }
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();