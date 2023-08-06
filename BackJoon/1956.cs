// 시작 도시가 정해지지 않았다는 것에 모든 도시에서 모든 도시로의 도로 길이가 필요하다고 판단 = 플로이드 워셜 알고리즘을 사용
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int v = input[0];
int e = input[1];

int a = 0;
int b = 0;
int c = 0;

List<List<int[]>> graph = new List<List<int[]>>();
for (int i = 0; i < v + 1; i++)
{
    graph.Add(new List<int[]>());
}

for (int i = 0; i < e; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    graph[a].Add(new int[2] { b, c });
}

// 배열 내부의 값을 INF와 0를 통해 자기자신과 갈 수 있는 도로가 없는 것을 구분하는 행위를 하지 않음
// v의 크기의 최대가 400이므로 전부 바꾸어주는 반복문을 사용하면 성능이 떨어질 것을 생각해, 0으로 둔뒤 아래 함수에서 구분하도록 함.
int[,] costs = new int[v + 1, v + 1]; 
for (int i = 1; i < v + 1; i++)
{
    foreach (int[] tmp in graph[i])
    {
        costs[i, tmp[0]] = tmp[1];
    }
}

Floyd_Washall();

int result = -1;

for (int i = 1; i < v + 1; i++)
{
    if (result == -1)
    {
        if (costs[i, i] != 0)
        {
            result = costs[i, i];
        }
    }
    else
    {
        if (costs[i, i] != 0 && result > costs[i, i])
        {
            result = costs[i, i];
        }
    }
}

sw.Write(result);
sw.Flush();
sw.Close();

void Floyd_Washall()
{
    for (int i = 1; i < v + 1; i++)
    {
        for (int j = 1; j < v + 1; j++)
        {
            if (i == j) // 자기 자신을 중간 경로로 설정할 경우
            {
                continue;
            }
            else
            {
                if (costs[j, i] == 0) // 특정지점에서 중간경로로 이동하는 도로가 없는 경우
                {
                    continue;
                }

                for (int k = 1; k < v + 1; k++)
                {
                    if (costs[i, k] == 0) // 중간 경로에서 특정지점으로 이동하는 도로가 없는 경우
                    {
                        continue;
                    }

                    if (costs[j, k] == 0)
                    {
                        costs[j, k] = costs[j, i] + costs[i, k];
                    }
                    else
                    {
                        if (costs[j, k] > costs[j, i] + costs[i, k])
                        {
                            costs[j, k] = costs[j, i] + costs[i, k];
                        }
                    }
                }
            }
        }
    }

}