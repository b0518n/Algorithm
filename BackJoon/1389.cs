int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

List<List<int>> list = new List<List<int>>();
for (int i = 0; i < n + 1; i++)
{
    list.Add(new List<int>());
}

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list[input[0]].Add(input[1]);
    list[input[1]].Add(input[0]);
}

int[] dp = null;
int[] visited = null;
int result = int.MaxValue;
int index = 0;
int value = 0;

for (int i = 1; i < n + 1; i++)
{
    dp = new int[n + 1];
    visited = new int[n + 1];
    value = 0;
    BFS(i);

    for (int j = 1; j < n + 1; j++)
    {
        value += dp[j];
    }

    if (result > value)
    {
        result = value;
        index = i;
    }
}

Console.WriteLine(index);



void BFS(int index)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(index);
    visited[index] = 1;
    int temp = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();

        foreach (int i in list[temp])
        {
            if (visited[i] == 1)
            {
                continue;
            }

            queue.Enqueue(i);
            visited[i] = 1;
            dp[i] = dp[temp] + 1;
        }
    }
}