StringBuilder sb = new StringBuilder();
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] parent = new int[n + 2];
for (int i = 0; i < n + 2; i++)
{
    parent[i] = i;
}

int type = 0;
int a = 0;
int b = 0;

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    type = input[0];
    a = input[1];
    b = input[2];

    if (type == 0)
    {
        merge(a, b, parent);
    }
    else
    {
        if (isUnion(a, b, parent))
        {
            sb.AppendLine("YES");
        }
        else
        {
            sb.AppendLine("NO");
        }
    }
}

Console.WriteLine(sb.ToString());

void merge(int x, int y, int[] parent)
{
    int _x = find(x, parent);
    int _y = find(y, parent);

    if (_x == _y)
    {
        return;
    }

    parent[_y] = _x;
    return;
}

int find(int x, int[] parent)
{
    int result = x;

    if (parent[x] == x)
    {
        return result;
    }

    result = find(parent[x], parent);

    return result;
}

bool isUnion(int x, int y, int[] parent)
{
    int _x = find(x, parent);
    int _y = find(y, parent);
    if (_x == _y)
    {
        return true;
    }

    return false;
}