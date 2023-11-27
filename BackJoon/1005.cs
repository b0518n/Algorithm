using System.Text;

StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int[] input = null;
int n = 0;
int k = 0;
int[] times = null;
Dictionary<int, int> dp = null;
List<List<int>> list = null;
int[] inDegrees = null;
int lastIndex = 0;
List<int> startIndexs = null;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    k = input[1];
    times = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    times = AddZero(); // 입력 인덱스와 배열의 인덱스를 맞춰주기 위해 맨앞 0을 대입
    dp = new Dictionary<int, int>(); // 메모리 사용을 줄이기 위해 : 배열 -> 딕셔너리
    list = new List<List<int>>();
    inDegrees = new int[n + 1];
    startIndexs = new List<int>();

    for (int j = 0; j < n + 1; j++)
    {
        list.Add(new List<int>());
    }

    for (int j = 0; j < k; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        list[input[0]].Add(input[1]);
        inDegrees[input[1]]++;
    }

    for (int j = 1; j < n + 1; j++)
    {
        if (inDegrees[j] == 0)
        {
            startIndexs.Add(j);
        }
    }

    lastIndex = int.Parse(Console.ReadLine());
    foreach (int _index in startIndexs)
    {
        BFS(_index);
    }

    sb.AppendLine(dp[lastIndex].ToString());
}

Console.WriteLine(sb.ToString());

int[] AddZero()
{
    List<int> temp = times.ToList();
    temp.Insert(0, 0);

    return temp.ToArray();
}

void BFS(int index)
{
    Queue<int> q = new Queue<int>();
    q.Enqueue(index);
    dp.Add(index, times[index]);

    int temp = 0;

    while (q.Count > 0)
    {
        temp = q.Dequeue();

        foreach (int _index in list[temp])
        {
            if (dp.ContainsKey(_index))
            {
                if (dp[_index] < dp[temp] + times[_index])
                {
                    dp[_index] = dp[temp] + times[_index];
                    q.Enqueue(_index);
                }
            }
            else
            {
                dp.Add(_index, dp[temp] + times[_index]);
                q.Enqueue(_index);
            }
        }
    }
}