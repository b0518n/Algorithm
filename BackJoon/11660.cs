StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int k = input[2];

int[,] arr_Black = new int[n + 1, m + 1];
int[,] arr_White = new int[n + 1, m + 1];

string str = null;

for (int i = 1; i < n + 1; i++)
{
    str = sr.ReadLine();
    for (int j = 1; j < m + 1; j++)
    {
        if (i % 2 == 0 && j % 2 == 0)
        {
            if (str[j - 1] == 'W')
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 0;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 1;
            }
            else
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 1;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 0;
            }
        }
        else if (i % 2 == 0 && j % 2 != 0)
        {
            if (str[j - 1] == 'W')
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 1;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 0;
            }
            else
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 0;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 1;
            }
        }
        else if (i % 2 != 0 && j % 2 == 0)
        {
            if (str[j - 1] == 'W')
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 1;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 0;
            }
            else
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 0;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 1;
            }
        }
        else
        {
            if (str[j - 1] == 'W')
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 0;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 1;
            }
            else
            {
                arr_Black[i, j] = arr_Black[i - 1, j] + arr_Black[i, j - 1] - arr_Black[i - 1, j - 1] + 1;
                arr_White[i, j] = arr_White[i - 1, j] + arr_White[i, j - 1] - arr_White[i - 1, j - 1] + 0;
            }
        }
    }

}

int black = arr_Black[n, m] - arr_Black[n - k, m] - arr_Black[n, m - k] + arr_Black[n - k, m - k];
int white = arr_White[n, m] - arr_White[n - k, m] - arr_White[n, m - k] + arr_White[n - k, m - k];

int result = black > white ? white : black;
sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();