using System.Text;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] minDisArr = new int[n + 1, n + 1];
string[,] firstPosArr = new string[n + 1, n + 1];
List<List<EdgeInfo>> edgeList = new List<List<EdgeInfo>>();

edgeList.Add(new List<EdgeInfo>());
for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (i == j)
        {
            firstPosArr[i, j] = "-";
        }
        else
        {
            minDisArr[i, j] = -1;
        }
    }

    edgeList.Add(new List<EdgeInfo>());
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    edgeList[input[0]].Add(new EdgeInfo(input[1], input[2]));
    edgeList[input[1]].Add(new EdgeInfo(input[0], input[2]));

    minDisArr[input[0], input[1]] = input[2];
    minDisArr[input[1], input[0]] = input[2];
    firstPosArr[input[0], input[1]] = input[1].ToString();
    firstPosArr[input[1], input[0]] = input[0].ToString();
}

for (int i = 1; i < n + 1; i++) // 중간 정점
{
    for (int j = 1; j < n + 1; j++) // 시작 정점
    {
        if (i == j)
            continue;
        if (minDisArr[j, i] == -1)
            continue;

        for (int k = 1; k < n + 1; k++)
        {
            if (i == k)
                continue;
            if (minDisArr[i, k] == -1)
                continue;

            if (minDisArr[j, k] == -1)
            {
                minDisArr[j, k] = minDisArr[j, i] + minDisArr[i, k];
                firstPosArr[j, k] = firstPosArr[j, i];
            }
            else
            {
                if (minDisArr[j, k] > minDisArr[j, i] + minDisArr[i, k])
                {
                    minDisArr[j, k] = minDisArr[j, i] + minDisArr[i, k];
                    firstPosArr[j, k] = firstPosArr[j, i];
                }
            }
        }
    }
}

StringBuilder sb = new StringBuilder();

for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (j == n)
        {
            if (i == n)
            {
                sb.Append(firstPosArr[i, j]);
            }
            else
            {
                sb.AppendLine(firstPosArr[i, j]);
            }
        }
        else
        {
            sb.Append(firstPosArr[i, j] + " ");
        }
    }
}

sw.WriteLine(sb.ToString());
sw.Flush();
sw.Close();

class EdgeInfo
{
    public int destination;
    public int distance;

    public EdgeInfo(int _destination, int _distance)
    {
        this.destination = _destination;
        this.distance = _distance;
    }
}