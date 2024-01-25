int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 행
int m = input[1]; // 열
int d = input[2]; // 궁수의 공격 거리 제한
int[,] field = new int[n + 1, m];
Dictionary<string, int> enemys = new Dictionary<string, int>();
List<List<int>> archorPositions = new List<List<int>>();

int result = -1;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        field[i, j] = input[j];
        if (input[j] == 1)
        {
            enemys.Add($"{i} {j}", 1);
        }
    }
}

SelectPlace(0, new List<int>());

for (int i = 0; i < archorPositions.Count; i++)
{
    Solve(DeepCopyDic(enemys), i);
}

Console.WriteLine(result);

void Solve(Dictionary<string, int> enemys, int i)
{
    int removeCnt = 0;

    while (enemys.Count > 0)
    {
        removeCnt += RemoveEnemy(enemys, i);
        MoveEnemy(ref enemys);
    }

    if (result == -1)
    {
        result = removeCnt;
    }
    else
    {
        result = Math.Max(result, removeCnt);
    }
}

void MoveEnemy(ref Dictionary<string, int> enemys)
{
    int ny = 0;
    int nx = 0;
    string[] temp = null;
    Dictionary<string, int> dic = new Dictionary<string, int>();

    foreach (string str in enemys.Keys)
    {
        temp = str.Split(" ");
        ny = int.Parse(temp[0]) + 1;
        nx = int.Parse(temp[1]);

        if (ny < n)
        {
            field[ny, nx] = 1;
            field[int.Parse(temp[0]), int.Parse(temp[1])] = 0;
            dic.Add($"{ny} {nx}", 1);
        }
    }

    enemys = DeepCopyDic(dic);
}

int RemoveEnemy(Dictionary<string, int> enemys, int index)
{
    List<ObjectInfo> list = new List<ObjectInfo>();
    int removeCnt = 0;
    ObjectInfo objectInfo = null;

    foreach (int i in archorPositions[index])
    {
        objectInfo = SelectRemoveEnemy(enemys, n, i);
        if (objectInfo.y == -1 && objectInfo.x == -1)
        {
            continue;
        }
        else
        {
            list.Add(objectInfo);
        }
    }

    foreach (ObjectInfo obj in list)
    {
        if (enemys.ContainsKey($"{obj.y} {obj.x}"))
        {
            enemys.Remove($"{obj.y} {obj.x}");
            removeCnt++;
        }
    }

    return removeCnt;
}

ObjectInfo SelectRemoveEnemy(Dictionary<string, int> enemys, int y, int x)
{
    string[] temp = null;
    int ny = -1;
    int nx = -1;

    int min = -1;
    int value = 0;
    int minY = -1;
    int minX = -1;

    foreach (string str in enemys.Keys)
    {
        temp = str.Split(" ");
        ny = int.Parse(temp[0]);
        nx = int.Parse(temp[1]);
        value = CalculateDistance(y, x, ny, nx);
        if (value > d)
        {
            continue;
        }

        if (min == -1)
        {
            min = value;
            minY = ny;
            minX = nx;
        }
        else
        {
            if (min > value)
            {
                min = value;
                minY = ny;
                minX = nx;
            }
            else if (min == value)
            {
                if (minX > nx)
                {
                    minY = ny;
                    minX = nx;
                }
            }
        }
    }

    return new ObjectInfo(minY, minX);
}

int CalculateDistance(int y1, int x1, int y2, int x2)
{
    return Math.Abs(y2 - y1) + Math.Abs(x2 - x1);
}

void SelectPlace(int startIndex, List<int> list)
{
    if (list.Count == 3)
    {
        archorPositions.Add(DeepCopyList(list));
    }

    for (int i = startIndex; i < m; i++)
    {
        list.Add(i);
        SelectPlace(i + 1, list);
        list.RemoveAt(list.Count - 1);
    }
}

List<int> DeepCopyList(List<int> list)
{
    List<int> temp = new List<int>();

    foreach (int i in list)
    {
        temp.Add(i);
    }

    return temp;
}

Dictionary<string, int> DeepCopyDic(Dictionary<string, int> dic)
{
    Dictionary<string, int> temp = new Dictionary<string, int>();

    foreach (string key in dic.Keys)
    {
        temp.Add(key, 1);
    }

    return temp;
}

class ObjectInfo
{
    public int y;
    public int x;

    public ObjectInfo(int y, int x)
    {
        this.y = y;
        this.x = x;
    }
}