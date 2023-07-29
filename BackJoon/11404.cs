StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine()); // 도시의 개수
int m = int.Parse(Console.ReadLine()); // 버스의 개수

int[] input = null;
// a에서 b로 비용은 c
int a = 0;
int b = 0;
long c = 0;

long[,] costs = new long[n + 1, n + 1];
for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (i != j)
        {
            costs[i, j] = long.MaxValue;
        }
    }
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    if (costs[a, b] == long.MaxValue)
    {
        costs[a, b] = c;
    }
    else
    {
        if (costs[a, b] > c)
        {
            costs[a, b] = c;
        }
    }
}

Floyd_Warshall();

for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < n + 1; j++)
    {
        if (j == 1)
        {
            if (costs[i, j] == long.MaxValue)
            {
                sw.Write(0);
            }
            else
            {
                sw.Write(costs[i, j]);
            }
        }
        else if (j == n)
        {
            if (costs[i, j] == long.MaxValue)
            {
                sw.WriteLine(" " + 0);
            }
            else
            {
                sw.WriteLine(" " + costs[i, j]);
            }
        }
        else
        {
            if (costs[i, j] == long.MaxValue)
            {
                sw.Write(" " + 0);
            }
            else
            {
                sw.Write(" " + costs[i, j]);
            }
        }
    }
}

sw.Flush();
sw.Close();

// Dijstra 양의 가중치만을 가질 때, 시작 정점에서 가장 비용이 적게 드는 정점을 방문하는 방식
// Belman_Ford 음의 가중치가 있을 경우, 정점의 개수가 n개 인경우 n - 1번 간선을 이용한 비용을 계산 후 마지막 한번 더 계산할 때
// 정점의 비용의 변화가 있을 경우 음의 사이클로 판단
// Floyd_Warshall 한 정점에서 다른 정점으로가 아닌 모든 정점에서 다른 정점으로의 최소 비용을 찾을 때 사용,
// 1번 부터  n번 정점까지 순서대로 중간에 방문하는 정점으로 설정하고 각 정점에서 설정된 중간에 방문하는 정점을 통한,
// 다른 정점으로의 최소비용을 계산하는 방식
void Floyd_Warshall()
{
    // 중간 지점을 i로 지정
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (i == j)
            {
                continue;
            }

            if (costs[j, i] == long.MaxValue)
            {
                continue;
            }

            for (int k = 1; k < n + 1; k++)
            {
                if (costs[i, k] == long.MaxValue || costs[i, k] == 0)
                {
                    continue;
                }

                if (costs[j, k] == long.MaxValue)
                {
                    costs[j, k] = costs[j, i] + costs[i, k];
                }
                else if (costs[j, k] != 0 && costs[j, k] > costs[j, i] + costs[i, k])
                {
                    costs[j, k] = costs[j, i] + costs[i, k];
                }
            }
        }
    }
}