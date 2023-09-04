int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int x = 0;
int y = 0;

List<int[]> gods = new List<int[]>();
gods.Add(new int[2] { 0, 0 });

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    x = input[0];
    y = input[1];

    gods.Add(new int[2] { x, y });
}

int[] parent = new int[n + 1];
for (int i = 1; i < n + 1; i++)
{
    parent[i] = i;
}

double length = 0.0f;
for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    Merge(input[0], input[1], parent, ref length, gods);
}

length = 0.0f;

double distance = 0;

List<object[]> lengths = new List<object[]>();

for (int i = 1; i < n + 1; i++)
{
    for (int j = i + 1; j < n + 1; j++)
    {
        distance = Distance(gods[i][0], gods[i][1], gods[j][0], gods[j][1]);
        lengths.Add(new object[3] { i, j, distance });
    }
}

lengths = lengths.OrderBy(arr => arr[2]).ToList();

for (int i = 0; i < lengths.Count; i++)
{
    Merge((int)lengths[i][0], (int)lengths[i][1], parent, ref length, gods);
}


string result = length.ToString("0.00");
Console.WriteLine(result);

int Find(int x, int[] parent)
{
    while (x != parent[x])
    {
        x = parent[x];
    }

    return x;
}

void Merge(int x, int y, int[] parent, ref double length, List<int[]> gods)
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

    length += Distance((double)gods[x][0], (double)gods[x][1], (double)gods[y][0], (double)gods[y][1]);
}

double Distance(double x1, double y1, double x2, double y2)
{
    return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
}