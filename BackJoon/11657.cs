StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 도시의 개수
int m = input[1]; // 노선의 개수

int a = 0;
int b = 0;
int c = 0;

List<int[]> edge = new List<int[]>();

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    edge.Add(new int[3] { a, b, c });

}

long[] times = new long[n + 1];
// underflow로 인한 출력초과 발생 : int -> long 변경해서 해결

for (int i = 1; i < n + 1; i++)
{
    times[i] = int.MaxValue;
}

bool result = Bellman_Ford();
if (result)
{
    sw.WriteLine(-1);
}
else
{
    for (int i = 2; i < n + 1; i++)
    {
        if (times[i] == int.MaxValue)
        {
            sw.WriteLine(-1);
        }
        else
        {
            sw.WriteLine(times[i]);
        }
    }
}

sw.Flush();
sw.Close();

// Dijstra의 경우 cost가 양수인 경우 사용
// Bellman_Ford의 경우 cost 값에 음수가 존재할 경우 사용
// 동작 원리
// 1. 모든 간선들을 탐색하면서 간선이 있는 출발정점이 한번이라도 계산된 정점이라면 해당 간선이 잇는 정점의 거리를 비교해서 업데이트
// 정점의 개수가 n개 일경우 1번 과정을 n - 1번 반복.
// 그 이후 1번 과정을 한번 더 반복해서 만약 times의 변화가 있을 경우 음의 가중치 때문에 최소비용이 계산 안되는 음의 사이클, 음수 사이클로 판단
bool Bellman_Ford()
{
    times[1] = 0;
    int from = 0;
    int to = 0;
    int cost = 0;

    for (int i = 1; i <= n - 1; i++)
    {
        for (int j = 0; j < m; j++)
        {
            from = edge[j][0];
            to = edge[j][1];
            cost = edge[j][2];

            if (times[from] == int.MaxValue)
            {
                continue;
            }

            if (times[to] > times[from] + cost)
            {
                times[to] = times[from] + cost;
            }
        }
    }

    for (int i = 0; i < m; i++)
    {
        from = edge[i][0];
        to = edge[i][1];
        cost = edge[i][2];

        if (times[from] == int.MaxValue)
        {
            continue;
        }

        if (times[to] > times[from] + cost)
        {
            return true;
        }
    }

    return false;
}