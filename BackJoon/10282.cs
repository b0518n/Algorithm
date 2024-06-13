StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());

int[] input = null;
int n = 0;
int d = 0;
int c = 0;

int[,] arr = new int[10001, 10001];
int[] visited = new int[10001];

int index = 0;
int min = 0;

int cnt = 1;
int time = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    n = input[0];
    d = input[1];
    c = input[2];

    cnt = 1;
    time = 0;

    InitArr();

    for (int j = 0; j < d; j++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        arr[input[1], input[0]] = input[2];
    }

    visited[c] = 1;
    while (true)
    {
        min = 0;
        index = 0;

        for (int j = 1; j < n + 1; j++)
        {
            if (visited[j] == 1)
                continue;
            if (arr[c, j] == int.MaxValue)
                continue;

            if (min == 0 && index == 0)
            {
                min = arr[c, j];
                index = j;
            }
            else
            {
                if (min > arr[c, j])
                {
                    min = arr[c, j];
                    index = j;
                }
            }
        }

        if (min == 0 && index == 0)
            break;

        visited[index] = 1;

        for (int j = 1; j < n + 1; j++)
        {
            if (arr[index, j] == int.MaxValue)
                continue;

            if (j == c)
                continue;

            if (arr[c, j] == int.MaxValue)
                arr[c, j] = arr[c, index] + arr[index, j];
            else
                arr[c, j] = Math.Min(arr[c, j], arr[c, index] + arr[index, j]);
        }
    }


    for (int j = 1; j < n + 1; j++)
    {
        if (arr[c, j] == int.MaxValue)
            continue;

        cnt++;
        time = Math.Max(time, arr[c, j]);
    }

    sw.WriteLine($"{cnt} {time}");
}

sw.Flush();
sw.Close();

void InitArr()
{
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            arr[i, j] = int.MaxValue;
        }

        visited[i] = 0;
    }
}