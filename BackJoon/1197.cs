int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int v = input[0];
int e = input[1];

int a = 0;
int b = 0;
int c = 0;

List<int[]> inputValues = new List<int[]>();
int[] parent = new int[v + 1];

for (int i = 1; i < v + 1; i++)
{
    parent[i] = i;
}

for (int i = 0; i < e; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];

    inputValues.Add(new int[3] { a, b, c });
}

inputValues = inputValues.OrderBy(arr => arr[2]).ToList();
int result = 0;

for (int i = 0; i < inputValues.Count; i++)
{
    Merge(inputValues[i][0], inputValues[i][1], parent, inputValues[i][2], ref result);
}

Console.WriteLine(result);

int Find(int x, int[] parent)
{
    while (x != parent[x])
    {
        x = parent[x];
    }

    return x;
}

void Merge(int x, int y, int[] parent, int cost, ref int result)
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

    result += cost;
    return;
}