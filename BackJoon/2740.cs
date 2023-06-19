StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] a = new int[n, m];
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < input.Length; j++)
    {
        a[i, j] = input[j];
    }
}

input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
m = input[0];
int k = input[1];

int[,] b = new int[m, k];
for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < input.Length; j++)
    {
        b[i, j] = input[j];
    }
}

int[,] arr = new int[n, k];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < k; j++)
    {
        for (int l = 0; l < m; l++)
        {
            arr[i, j] += a[i, l] * b[l, j];
            if (l == m - 1)
            {
                if (j == k - 1)
                {
                    sw.WriteLine(arr[i, j]);
                }
                else
                {
                    sw.Write(arr[i, j] + " ");
                }
            }
        }
    }
}

sw.Flush();
sw.Close();
sr.Close();