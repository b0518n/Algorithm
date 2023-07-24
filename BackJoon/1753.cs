StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int v = input[0]; // 정점의 개수
int e = input[1]; // 간선의 개수
int k = int.Parse(Console.ReadLine()); // 시작 정점

int a = 0;
int b = 0;
int c = 0;

int[] cost = new int[v + 1];
int[] visited = new int[v + 1];

// 처음에는 v + 1 * v + 1 크기의 2차원 배열을 사용했으나 메모리 초과로 발생
// 그래서 메모리 사용을 줄이기 위해 리스트안에 크기가 2인 배열을 넣어 인덱스 0 에는 도착 정점의 값을, 1에는 가중치를 넣어서 사용
List<List<int[]>> list = new List<List<int[]>>();

for (int i = 0; i < v + 1; i++)
{
    list.Add(new List<int[]>());
}

for (int i = 0; i < e; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    // a에서 b로 (방향 그래프)
    a = input[0];
    b = input[1];
    c = input[2]; // 가중치

    list[a].Add(new int[2] { b, c });
}

Solve(k);
cost[k] = 0;

for (int i = 1; i < v + 1; i++)
{
    if (cost[i] == 0)
    {
        if (i == k)
        {
            sw.WriteLine(0);
        }
        else
        {
            sw.WriteLine("INF");
        }
    }
    else
    {
        sw.WriteLine(cost[i]);
    }
}

sw.Flush();
sw.Close();

// 다익스트라 알고리즘
// 방문하지 않은 정점 중 비용이 가장 적은 정점을 방문 하는 방식
void Solve(int start)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(start);
    int tmp = 0;
    int min = 200001;
    int index = -1;


    while (q.Count > 0)
    {
        tmp = q.Dequeue();
        visited[tmp] = 1;
        min = 200001;
        index = -1;

        // 해당 정점에서 갈 수 있는 정점들의 비용 계산
        foreach (int[] temp in list[tmp])
        {
            if (cost[temp[0]] == 0)
            {
                cost[temp[0]] = cost[tmp] + temp[1];
            }
            else
            {
                if (cost[temp[0]] > cost[tmp] + temp[1])
                {
                    cost[temp[0]] = cost[tmp] + temp[1];
                }
            }
        }

        // 방문한 적이 없는 정점 중 갈 수 있는 비용이 가장 적은 정점을 고르는 반복문
        for (int i = 1; i < v + 1; i++)
        {
            if (visited[i] == 0 && cost[i] != 0)
            {
                if (min > cost[i])
                {
                    min = cost[i];
                    index = i;
                }
            }
        }

        // index = -1인 경우
        // 모든 정점을 방문 했거나, 방문할 수 없는 정점만 남은 경우 반복문을 종료하기 위해 큐에 값을 넣지 않음으로써 종료시킴
        if (index != -1)
        {
            q.Enqueue(index);
        }
    }
}
