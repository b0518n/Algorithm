StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

string str = null;
int[,] paper = new int[n, m];

for (int i = 0; i < n; i++)
{
    str = sr.ReadLine();
    for (int j = 0; j < m; j++)
    {
        paper[i, j] = int.Parse(str[j].ToString());
    }
}

int[,] arr = new int[n, m];
int result = int.MinValue;

DividePaper(0, 0);
sw.WriteLine(result);
sw.Flush();
sw.Close();

void DividePaper(int y, int x)
{
    if (y >= n)
    {
        CalculateMax();
        return;
    }

    for (int i = 0; i < 2; i++)
    {
        if (i == 0)
        {
            arr[y, x] = 1;
        }
        else
        {
            arr[y, x] = 2;
        }

        if (x < m - 1)
        {
            DividePaper(y, x + 1);
            arr[y, x] = 0;
        }
        else if (x == m - 1)
        {
            DividePaper(y + 1, 0);
            arr[y, x] = 0;
        }
    }
}

void CalculateMax()
{
    int[,] visited = new int[n, m];

    int temp = 0;
    int y = 0;
    int x = 0;
    int ny = 0;
    int nx = 0;
    int isRow = 0; // 0 : 초기, 1 : row, 2 : column
    int retValue = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (visited[i, j] == 0)
            {
                temp = 0;
                y = i;
                x = j;
                isRow = 0;
                visited[y, x] = 1;

                while (true)
                {
                    if (arr[y, x] == 1 && !(isRow == 2))
                    {
                        temp = temp * 10 + paper[y, x];
                        ny = y;
                        nx = x + 1;
                        isRow = 1;
                    }
                    else if (arr[y, x] == 2 && !(isRow == 1))
                    {
                        temp = temp * 10 + paper[y, x];
                        ny = y + 1;
                        nx = x;
                        isRow = 2;
                    }
                    else
                    {
                        retValue += temp;
                        break;
                    }

                    if (ny < 0 || nx < 0 || ny >= n || nx >= m)
                    {
                        retValue += temp;
                        break;
                    }

                    visited[ny, nx] = 1;
                    y = ny;
                    x = nx;
                }
            }
        }
    }

    result = Math.Max(result, retValue);
}