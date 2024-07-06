StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int m = int.Parse(sr.ReadLine());

int[,] relationshipArr = new int[n + 1, n + 1];
int[] input = null;

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
    relationshipArr[input[0], input[1]] = 1;
    relationshipArr[input[1], input[0]] = 1;
}

Floyd_Warshall_Func();
GetCommitteeCnt();

void Floyd_Warshall_Func()
{
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
                if (k == i)
                    continue;
                if (relationshipArr[i, k] == int.MaxValue)
                    continue;

                if (relationshipArr[j, k] == int.MaxValue)
                    relationshipArr[j, k] = relationshipArr[j, i] + relationshipArr[i, k];
                else
                {
                    if (relationshipArr[j, k] > relationshipArr[j, i] + relationshipArr[i, k])
                    {
                        relationshipArr[j, k] = relationshipArr[j, i] + relationshipArr[i, k];
                    }
                }

            }
        }
    }
}
void GetCommitteeCnt()
{
    int[] visited = new int[n + 1];
    Queue<int> q = new Queue<int>();
    int temp = 0;

    int max = -1;

    int min = -1;
    int index = -1;
    List<int> list = new List<int>();

    for (int i = 1; i < n + 1; i++)
    {
        if (visited[i] == 1)
            continue;

        for (int j = 1; j < n + 1; j++)
        {
            if (relationshipArr[i, j] == 0 || relationshipArr[i, j] == int.MaxValue)
                continue;

            visited[j] = 1;
            q.Enqueue(j);
        }

        q.Enqueue(i);

        while (q.Count > 0)
        {
            max = -1;
            temp = q.Dequeue();
            for (int j = 1; j < n + 1; j++)
            {
                if (relationshipArr[temp, j] == 0 || relationshipArr[temp, j] == int.MaxValue)
                    continue;
                if (max == -1)
                    max = relationshipArr[temp, j];
                else
                    max = Math.Max(max, relationshipArr[temp, j]);
            }

            if (min == -1 && index == -1)
            {
                min = max;
                index = temp;
            }
            else
            {
                if (min > max)
                {
                    min = max;
                    index = temp;
                }
            }

            if (q.Count == 0 && min == -1 && index == -1)
            {
                min = 0;
                index = temp;
            }
        }

        list.Add(index);
        min = -1;
        index = -1;
    }

    list.Sort();
    sw.WriteLine(list.Count);
    for (int i = 0; i < list.Count; i++)
    {
        sw.WriteLine(list[i]);
    }

    sw.Flush();
    sw.Close();
}