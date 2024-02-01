StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int h = input[2];

int[,] arr = new int[h, n];
for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    arr[input[0] - 1, input[1] - 1] = 1;
    arr[input[0] - 1, input[1]] = -1;
}

int result = -1;
BackTracking(0, 0, 0);
sw.WriteLine(result);
sw.Close();

void BackTracking(int y, int x, int cnt)
{
    if (cnt > 3)
    {
        return;
    }

    UpdateResult(cnt);

    int i = y;
    int j = x;

    for (; i < h; i++)
    {
        j = 0;
        for (; j < n; j++)
        {
            if (arr[i, j] == 0)
            {
                if (j - 1 >= 0 && j + 1 <= n - 1)
                {
                    if (j + 1 == n - 1)
                    {
                        if ((arr[i, j - 1] == 0 || arr[i, j - 1] == -1) && arr[i, j + 1] == 0)
                        {
                            AddLine(i, j);
                            BackTracking(i, j + 1, cnt + 1);
                            RemoveLine(i, j);
                        }
                    }
                    else
                    {
                        if ((arr[i, j - 1] == 0 || arr[i, j - 1] == -1) && arr[i, j + 1] == 0 && (arr[i, j + 2] == 0 || arr[i, j + 2] == 1))
                        {
                            AddLine(i, j);
                            BackTracking(i, j + 1, cnt + 1);
                            RemoveLine(i, j);
                        }
                    }

                }
                else if (j - 1 < 0 && j + 1 <= n - 1)
                {
                    if (j + 1 == n - 1)
                    {
                        if (arr[i, j + 1] == 0)
                        {
                            AddLine(i, j);
                            BackTracking(i, j + 1, cnt + 1);
                            RemoveLine(i, j);
                        }
                    }
                    else
                    {
                        if (arr[i, j + 1] == 0 && (arr[i, j + 2] == 0 || arr[i, j + 2] == 1))
                        {
                            AddLine(i, j);
                            BackTracking(i, j + 1, cnt + 1);
                            RemoveLine(i, j);
                        }
                    }
                }
            }
        }
    }

}

void UpdateResult(int cnt)
{
    if (StartLadderGame() == true)
    {
        if (result == -1)
        {
            result = cnt;
        }
        else
        {
            result = Math.Min(result, cnt);
        }
    }
}

bool StartLadderGame()
{
    int column = -1;

    for (int i = 0; i < n; i++)
    {
        column = i;
        for (int j = 0; j < h; j++)
        {
            if (arr[j, column] == 0)
            {
                continue;
            }
            else if (arr[j, column] == 1)
            {
                column++;
            }
            else if (arr[j, column] == -1)
            {
                column--;
            }
        }

        if (column != i)
        {
            return false;
        }
    }

    return true;
}

void AddLine(int y, int x)
{
    arr[y, x] = 1;
    arr[y, x + 1] = -1;
}

void RemoveLine(int y, int x)
{
    arr[y, x] = 0;
    arr[y, x + 1] = 0;
}