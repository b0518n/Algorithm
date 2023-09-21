int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[,] dp = new int[n, n];
List<int[]> houses = new List<int[]>();
List<int[]> chickens = new List<int[]>();
Stack<int> stack = new Stack<int>();
List<List<int>> list = new List<List<int>>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < n; j++)
    {
        dp[i, j] = input[j];
        if (dp[i, j] == 1)
        {
            houses.Add(new int[2] { i, j });
        }

        if (dp[i, j] == 2)
        {
            chickens.Add(new int[2] { i, j });
        }
    }
}

Recursion(-1, 0);

int min = int.MaxValue;

for (int i = 0; i < list.Count; i++)
{
    int distance = 0;
    for (int k = 0; k < houses.Count; k++)
    {
        int value = 101;
        for (int j = 0; j < list[i].Count; j++)
        {
            value = Math.Min(value, Distance(houses[k][0], houses[k][1], chickens[list[i][j]][0], chickens[list[i][j]][1]));
        }

        distance += value;
    }

    min = Math.Min(min, distance);
}

Console.WriteLine(min);

int Distance(int y1, int x1, int y2, int x2)
{
    return Math.Abs(y1 - y2) + Math.Abs(x1 - x2);
}


void Recursion(int index, int count)
{
    if (count == m)
    {
        List<int> temp = new List<int>();
        foreach (int i in stack)
        {
            temp.Add(i);
        }

        list.Add(temp);
        return;
    }

    for (int i = index + 1; i < chickens.Count; i++)
    {
        stack.Push(i);
        Recursion(i, count + 1);
        stack.Pop();
    }
}