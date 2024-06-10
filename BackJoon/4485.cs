StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
int[,] arr;
int[] input;

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { -1, 1, 0, 0 };

int result = 0;
int cnt = 1;

while (true)
{
    n = int.Parse(sr.ReadLine());
    if (n == 0)
        break;

    arr = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (int j = 0; j < n; j++)
        {
            arr[i, j] = input[j];
        }
    }

    Dijstra_Fun(cnt);
    cnt++;
}

sw.Flush();
sw.Close();

void Dijstra_Fun(int _sequence)
{
    int[,] tempArr = new int[n, n];
    int[,] visited = new int[n, n];
    visited[0, 0] = 1;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (i == 0 && j == 0)
                continue;

            tempArr[i, j] = int.MaxValue;
        }
    }

    tempArr[0, 1] = arr[0, 1];
    tempArr[1, 0] = arr[1, 0];

    int min = int.MaxValue;
    int minPosY = 0;
    int minPosX = 0;

    int ny = 0;
    int nx = 0;

    while (true)
    {
        min = int.MaxValue;
        minPosY = 0;
        minPosX = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                if (visited[i, j] == 1)
                    continue;

                if (tempArr[i, j] == int.MaxValue)
                    continue;

                if (min == int.MaxValue)
                {
                    min = tempArr[i, j];
                    minPosY = i;
                    minPosX = j;
                }
                else
                {
                    if (min > tempArr[i, j])
                    {
                        min = tempArr[i, j];
                        minPosY = i;
                        minPosX = j;
                    }
                }
            }
        }

        visited[minPosY, minPosX] = 1;

        for (int i = 0; i < 4; i++)
        {
            ny = minPosY + dy[i];
            nx = minPosX + dx[i];

            if (ny < 0 || nx < 0 || ny >= n || nx >= n)
                continue;
            if (tempArr[ny, nx] == int.MaxValue)
            {
                tempArr[ny, nx] = tempArr[minPosY, minPosX] + arr[ny, nx];
            }
            else
            {
                if (tempArr[ny, nx] > tempArr[minPosY, minPosX] + arr[ny, nx])
                {
                    tempArr[ny, nx] = tempArr[minPosY, minPosX] + arr[ny, nx];
                }
            }
        }

        if (tempArr[n - 1, n - 1] != int.MaxValue)
        {
            sw.WriteLine($"Problem {_sequence}: {tempArr[n - 1, n - 1] + arr[0, 0]}");
            break;
        }
    }





}