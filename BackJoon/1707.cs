StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int k = int.Parse(Console.ReadLine());

int[] input = null;

int v = 0; // 정점의 개수
int e = 0; // 간선의 개수
           // 정점의 번호
int a = 0;
int b = 0;

List<List<int>> list = null;
int[] visited = null;
bool flag = false;

for (int i = 0; i < k; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    v = input[0];
    e = input[1];

    list = new List<List<int>>();
    visited = new int[v + 1];

    for (int j = 0; j < v + 1; j++)
    {
        list.Add(new List<int>());
    }

    for (int j = 0; j < e; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        a = input[0];
        b = input[1];

        list[a].Add(b);
        list[b].Add(a);
    }

    for (int j = 1; j < v + 1; j++)
    {
        DFS(list, visited, j, 1);
    }

    flag = false;

    for (int j = 1; j < v + 1; j++)
    {
        if (flag)
        {
            break;
        }

        foreach (int tmp in list[j])
        {
            if (visited[j] == visited[tmp])
            {
                flag = true;
                break;
            }
        }
    }

    if (flag)
    {
        sw.WriteLine("NO");
    }
    else
    {
        sw.WriteLine("YES");
    }

}

sw.Flush();
sw.Close();

void DFS(List<List<int>> list, int[] visited, int index, int value)
{
    if (visited[index] == 0)
    {
        if (value == 1)
        {
            visited[index] = 2;
            foreach (int i in list[index])
            {
                DFS(list, visited, i, 2);
            }
        }
        else if (value == 2)
        {
            visited[index] = 1;
            foreach (int i in list[index])
            {
                DFS(list, visited, i, 1);
            }
        }
    }
}