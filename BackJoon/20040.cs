int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

List<int[]> connectedDots = new List<int[]>();

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    connectedDots.Add(new int[2] { input[0], input[1] });
}

int[] dp = new int[n];
Initialize(dp);

for (int i = 0; i < connectedDots.Count; i++)
{
    if (find(connectedDots[i][0], dp) == find(connectedDots[i][1], dp))
    {
        Console.WriteLine(i + 1);
        break;
    }
    else
    {
        merge(connectedDots[i][0], connectedDots[i][1], dp);
        if (i == connectedDots.Count - 1)
        {
            Console.WriteLine(0);
        }
    }
}

void Initialize(int[] arr)
{
    int length = arr.Length;
    for (int i = 0; i < length; i++)
    {
        arr[i] = i;
    }
}

int find(int x, int[] parent)
{
    while (x != parent[x])
    {
        x = parent[x];
    }

    return x;
}

void merge(int x, int y, int[] parent)
{
    int _x = find(x, parent);
    int _y = find(y, parent);

    if (_x > _y)
    {
        parent[_x] = _y;
    }
    else
    {
        parent[_y] = _x;
    }
}