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

int black = 0;
int White = 0;
int min = 4000001;

for (int i = 0; i <= n - k; i++)
{
    for (int j = 0; j <= m - k; j++)
    {
        black = arr_Black[k + i, k + j] - arr_Black[k + i, j] - arr_Black[i, k + j] + arr_Black[i, j];
        White = arr_White[k + i, k + j] - arr_White[k + i, j] - arr_White[i, k + j] + arr_White[i, j];

        if (min > black)
        {
            min = black;
        }

        if (min > White)
        {
            min = White;
        }
    }
}

int result = min;
sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();