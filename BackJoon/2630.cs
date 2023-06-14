StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] input = null;
int[,] arr = new int[n, n];
int blue = 0;
int white = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    for (int j = 0; j < input.Length; j++)
    {
        arr[i, j] = input[j];
    }
}

Divide(arr, n, 0, 0);
sw.WriteLine(white);
sw.WriteLine(blue);
sw.Flush();
sw.Close();
sr.Close();
void Divide(int[,] arr, int length, int y, int x)
{
    int sum = 0;

    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < length; j++)
        {
            sum += arr[y + i, x + j];
        }
    }

    if (sum == 0)
    {
        white++;
        return;
    }
    else if (sum == (length * length))
    {
        blue++;
        return;
    }
    else
    {
        Divide(arr, length / 2, y, x);
        Divide(arr, length / 2, y + length / 2, x);
        Divide(arr, length / 2, y, x + length / 2);
        Divide(arr, length / 2, y + length / 2, x + length / 2);
        return;
    }
}