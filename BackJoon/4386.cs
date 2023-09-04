int n = int.Parse(Console.ReadLine());
float[] input = null;

List<float[]> stars = new List<float[]>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), float.Parse);
    stars.Add(new float[2] { input[0], input[1] });
}

List<object[]> list = new List<object[]>();

for (int i = 0; i < n; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        object[] temp = new object[3];
        temp[0] = i;
        temp[1] = j;
        temp[2] = Distance(stars[i][0], stars[i][1], stars[j][0], stars[j][1]);

        list.Add(temp);
    }
}

list = list.OrderBy(arr => arr[2]).ToList();
int[] parent = new int[n];
float cost = 0;

for (int i = 0; i < n; i++)
{
    parent[i] = i;
}

for (int i = 0; i < list.Count; i++)
{
    if (Merge((int)list[i][0], (int)list[i][1], parent))
    {
        cost += (float)list[i][2];
    }
}

string result = cost.ToString("0.00");
Console.WriteLine(result);

float Distance(float x1, float y1, float x2, float y2)
{
    return MathF.Sqrt(MathF.Pow(x1 - x2, 2) + MathF.Pow(y1 - y2, 2));
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