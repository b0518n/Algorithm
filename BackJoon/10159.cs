StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int m = int.Parse(sr.ReadLine());

int[] input = null;
int[,] relationshipArr = new int[n + 1, n + 1];

for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (i == j)
            continue;
        relationshipArr[i, j] = int.MaxValue;
    }
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    relationshipArr[input[0], input[1]] = -1;
    relationshipArr[input[1], input[0]] = 1;
}

for (int i = 1; i < n + 1; i++) // 중간
{
    for (int j = 1; j < n + 1; j++) // 시작
    {
        if (i == j)
            continue;
        if (relationshipArr[j, i] == int.MaxValue)
            continue;

        for (int k = 1; k < n + 1; k++) // 끝
        {
            if (i == k)
                continue;
            if (relationshipArr[i, k] == int.MaxValue)
                continue;

            if (relationshipArr[j, k] == int.MaxValue)
            {
                if (relationshipArr[j, i] == relationshipArr[i, k])
                    relationshipArr[j, k] = relationshipArr[i, k];
            }
        }
    }
}

int _cnt = 0;

for (int i = 1; i < n + 1; i++)
{
    _cnt = 0;
    for (int j = 1; j < n + 1; j++)
    {
        if (relationshipArr[i, j] == int.MaxValue)
            _cnt++;
    }

    sw.WriteLine(_cnt);
}

sw.Flush();
sw.Close();