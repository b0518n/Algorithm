StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());

string input = null;

int[,] houses = new int[n, n];
int[,] visited = new int[n, n];

int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { 1, -1, 0, 0 };

int count = 0;
List<int> resultList = new List<int>();
int hCount = 0;

for (int i = 0; i < n; i++)
{
    input = Console.ReadLine();
    for (int j = 0; j < n; j++)
    {
        houses[i, j] = int.Parse(input[j].ToString());
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        DFS_Start(houses, visited, i, j);
    }
}

resultList.Sort(); // 각 단지 내 집의 수를 오름차순으로 정렬

sw.WriteLine(count);
for (int i = 0; i < resultList.Count; i++)
{
    sw.WriteLine(resultList[i]);
}

sw.Flush();
sw.Close();

// 해당 단지의 집들 중 하나를 처음 방문했을 때 해당 함수를 사용하고, 그 이후에 인접해잇는 집, 즉 같은 단지에 있는 집은 다른 함수를 이용해,
// count의 크기를 증가시키지 않음으로써 단지의 개수를 세기 위해서 함수를 나누었음.
// DFS, DFS_Start 함수 모두 hCount를 증가시킴으로써 단지 안의 집의 개수를 얻었으며, 해당 단지의 집을 모두 카운트한 이후에는 DFS_Start에서 값을 초기화하는 방식으로
// 모든 단지의 개수를 카운트함.
void DFS_Start(int[,] houses, int[,] visited, int y, int x)
{
    if (y < 0 || x < 0 || y >= n || x >= n)
    {
        return;
    }

    if (visited[y, x] != 0 || houses[y, x] == 0)
    {
        return;
    }

    visited[y, x] = 1;
    count++;
    hCount++;
    for (int i = 0; i < 4; i++)
    {
        DFS(houses, visited, y + dy[i], x + dx[i]);
    }

    resultList.Add(hCount);
    hCount = 0;
}

void DFS(int[,] houses, int[,] visited, int y, int x)
{
    if (y < 0 || x < 0 || y >= n || x >= n)
    {
        return;
    }

    if (visited[y, x] != 0 || houses[y, x] == 0)
    {
        return;
    }

    visited[y, x] = 1;
    hCount++;
    for (int i = 0; i < 4; i++)
    {
        DFS(houses, visited, y + dy[i], x + dx[i]);
    }
}