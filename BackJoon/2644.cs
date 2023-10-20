int n = int.Parse(Console.ReadLine());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];
int m = int.Parse(Console.ReadLine());
int x = 0;
int y = 0;
int result = -1;
List<List<int>> list = new List<List<int>>();
int[] visited = new int[n + 1];

for (int i = 0; i < n + 1; i++)
{
    list.Add(new List<int>());
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    x = input[0]; // 부모
    y = input[1]; // 자식

    list[x].Add(y);
    list[y].Add(x);
}

visited[a] = 1;
BFS(a, 0);

Console.WriteLine(result);

void BFS(int index, int value)
{
    if (index == b)
    {
        result = value;
        return;
    }

    foreach (int i in list[index])
    {
        if (visited[i] == 1)
        {
            continue;
        }

        visited[i] = 1;
        BFS(i, value + 1);
        visited[i] = 0;
    }
}