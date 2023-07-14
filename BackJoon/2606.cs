/*
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine()); // 컴퓨터의 수, 100이하인 양의 정수
int k = int.Parse(Console.ReadLine());

int[] input = null;
List<int>[] arr = new List<int>[n + 1];
int[] state = new int[n + 1];

for (int i = 0; i < n + 1; i++)
{
    arr[i] = new List<int>();
}

for (int i = 0; i < k; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    arr[input[0]].Add(input[1]);
    arr[input[1]].Add(input[0]);
}

DFS(arr, 1);
int count = 0;

for (int i = 2; i < n + 1; i++)
{
    if (state[i] == -1)
    {
        count++;
    }
}

sw.WriteLine(count);
sw.Flush();
sw.Close();

void DFS(List<int>[] arr, int start)
{
    int index = start;
    if (state[index] == 0) state[index] = -1;

    while (arr[index].Count > 0)
    {
        int tmp = arr[index].Count - 1;
        if (state[arr[index][tmp]] == 0)
        {
            DFS(arr, arr[index][tmp]);
        }

        arr[index].RemoveAt(arr[index].Count - 1);
    }
}
*/

StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine()); // 컴퓨터의 수, 100이하인 양의 정수
int k = int.Parse(Console.ReadLine());

int[] input = null;

bool[] visited = new bool[n + 1];
List<List<int>> list = new List<List<int>>();
for (int i = 0; i < n + 1; i++)
{
    list.Add(new List<int>());
}

for (int i = 0; i < k; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list[input[0]].Add(input[1]);
    list[input[1]].Add(input[0]);
}

DFS(list, 1);

int count = 0;
for (int i = 2; i < n + 1; i++)
{
    if (visited[i])
    {
        count++;
    }
}

sw.WriteLine(count);
sw.Flush();
sw.Close();

void DFS(List<List<int>> list, int start)
{
    visited[start] = true;
    foreach (int i in list[start])
    {
        if (!visited[i])
        {
            DFS(list, i);
        }
    }
}