StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 정점의 개수
int m = input[1]; // 간선의 개수
int v = input[2]; // 탐색을 시작할 정점의 번호

List<List<int>> list = new List<List<int>>();
for (int i = 0; i < n + 1; i++)
{
    list.Add(new List<int>());
}

int[] visited_DFS = new int[n + 1];
int[] visited_BFS = new int[n + 1];

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    // 간선은 양방향
    list[input[0]].Add(input[1]);
    list[input[1]].Add(input[0]);
}

for (int i = 1; i < n + 1; i++)
{
    list[i].Sort();
}

int count = 1;
DFS(list, v, count);

sw.WriteLine();
count = 1;
BFS(list, v, count);

sw.Flush();
sw.Close();


void DFS(List<List<int>> list, int start, int count)
{
    visited_DFS[start] = count;
    if (start == v)
    {
        sw.Write(start);
    }
    else
    {
        sw.Write(" " + start);
    }

    foreach (int i in list[start])
    {
        if (visited_DFS[i] == 0)
        {
            DFS(list, i, count + 1);
        }
    }
}

void BFS(List<List<int>> list, int start, int count)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(start);
    visited_BFS[start] = count;
    count++;
    sw.Write(start);

    while (queue.Count > 0)
    {
        int index = queue.Dequeue();

        foreach (int i in list[index])
        {
            if (visited_BFS[i] == 0)
            {
                queue.Enqueue(i);
                visited_BFS[i] = count;
                count++;
                sw.Write(" " + i);
            }
        }
    }
}