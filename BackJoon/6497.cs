int[] input = null;
int m = 0;
int n = 0;

int x = 0;
int y = 0;
int z = 0;

int[] parent = null;

List<int[]> list = null;
int max = 0;

int[] end = null;

while (true)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    m = input[0];
    n = input[1];

    if (m == 0 && n == 0)
    {
        break;
    }

    parent = new int[m];
    for (int i = 0; i < m; i++)
    {
        parent[i] = i;
    }

    x = 0;
    y = 0;
    z = 0;

    list = new List<int[]>();
    max = 0;

    for (int i = 0; i < n; i++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        x = input[0];
        y = input[1];
        z = input[2];

        list.Add(new int[3] { x, y, z });
        max += z;
    }

    list = list.OrderBy(arr => arr[2]).ToList();
    int cost = 0;

    for (int i = 0; i < list.Count; i++)
    {
        if (Merge(list[i][0], list[i][1], parent))
        {
            cost += list[i][2];
        }
    }

    int result = max - cost;
    Console.WriteLine(result);
}

int Find(int x, int[] parent)
{
    while (x != parent[x])
    {
        x = parent[x];
    }

    return x;
}

bool Merge(int x, int y, int[] parent)
{
    int _x = Find(x, parent);
    int _y = Find(y, parent);

    if (_x == _y)
    {
        return false;
    }

    if (_x > _y)
    {
        parent[_x] = _y;
    }
    else
    {
        parent[_y] = _x;
    }

    return true;
}