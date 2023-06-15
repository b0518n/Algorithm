StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[,] arr = new int[n, n];
string str = null;

for (int i = 0; i < n; i++)
{
    str = sr.ReadLine();
    for (int j = 0; j < str.Length; j++)
    {
        arr[i, j] = (str[j] - 48);
    }
}

Divide(arr, n, 0, 0);
sw.Flush();
sw.Close();
sr.Close();
void Divide(int[,] arr, int length, int y, int x)
{
    int sum = 0;

    for (int i = y; i < y + length; i++)
    {
        for (int j = x; j < x + length; j++)
        {
            sum += arr[i, j];
        }
    }

    if (sum == 0)
    {
        sw.Write(0);
    }
    else if (sum == length * length)
    {
        sw.Write(1);
    }
    else
    {
        sw.Write("(");
        Divide(arr, length / 2, y, x);
        Divide(arr, length / 2, y, x + length / 2);
        Divide(arr, length / 2, y + length / 2, x);
        Divide(arr, length / 2, y + length / 2, x + length / 2);
        sw.Write(")");
    }
}