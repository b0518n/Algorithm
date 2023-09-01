StringBuilder sb = new StringBuilder();
int t = int.Parse(Console.ReadLine());
int[] input = null;
int n = 0; // 국가의 수
int m = 0; // 비행기의 종류
int[] parent = null;
int count = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    m = input[1];

    parent = new int[n + 1];
    Initialize(parent);

    count = 0;
    for (int j = 0; j < m; j++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Merge(input[0], input[1], parent, ref count);
    }

    sb.AppendLine(count.ToString());
}

Console.WriteLine(sb.ToString());

int Find(int x, int[] parent)
{
    while (x != parent[x])
    {
        x = parent[x];
    }

    return x;
}

void Merge(int x, int y, int[] parent, ref int count)
{
    int _x = Find(x, parent);
    int _y = Find(y, parent);

    if (_x == _y)
    {
        return;
    }

    if (_x > _y)
    {
        parent[_x] = _y;
    }
    else
    {
        parent[_y] = _x;
    }

    count++;
}

void Initialize(int[] parent)
{
    int length = parent.Length;

    for (int i = 1; i < length; i++)
    {
        parent[i] = i;
    }
}