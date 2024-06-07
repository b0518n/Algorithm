StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int m = int.Parse(sr.ReadLine());

int[] input = null;
int[,] distanceArr = new int[n + 1, n + 1];
int[] visited = new int[n + 1];

for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        distanceArr[i, j] = int.MaxValue;
    }
}

int start;
int end;
int distance;

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    start = input[0];
    end = input[1];
    distance = input[2];

    if (start == end)
        continue;

    if (distanceArr[start, end] == int.MaxValue)
        distanceArr[start, end] = distance;
    else
    {
        if (distanceArr[start, end] > distance)
        {
            distanceArr[start, end] = distance;
        }
    }

}

input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int startPos = input[0];
int endPos = input[1];


sw.WriteLine(GetMinDistance_Fun(startPos, endPos));
sw.Flush();
sw.Close();

int GetMinDistance_Fun(int _startPos, int _endPos)
{
    int min = int.MaxValue;
    int index = 0;
    bool isSelected = false;

    for (int i = 1; i < n - 1; i++)
    {
        min = int.MaxValue;
        index = 0;
        isSelected = false;

        for (int j = 1; j < n + 1; j++)
        {
            if (_startPos == j)
                continue;
            if (distanceArr[_startPos, j] == int.MaxValue)
                continue;
            if (visited[j] == 1)
                continue;

            if (min == int.MaxValue)
            {
                min = distanceArr[_startPos, j];
                index = j;
                isSelected = true;
            }
            else
            {
                if (min > distanceArr[_startPos, j])
                {
                    min = distanceArr[_startPos, j];
                    index = j;
                }
            }
        }

        if (!isSelected)
            break;

        visited[index] = 1;

        for (int j = 1; j < n + 1; j++)
        {
            if (index == j)
                continue;
            if (distanceArr[index, j] == int.MaxValue)
                continue;

            if (distanceArr[_startPos, j] == int.MaxValue)
            {
                distanceArr[_startPos, j] = distanceArr[_startPos, index] + distanceArr[index, j];
            }
            else
            {
                if (distanceArr[_startPos, j] > distanceArr[_startPos, index] + distanceArr[index, j])
                {
                    distanceArr[_startPos, j] = distanceArr[_startPos, index] + distanceArr[index, j];
                }
            }
        }
    }

    return distanceArr[_startPos, _endPos];
}