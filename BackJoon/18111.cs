int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
int b = input[2];

Dictionary<int, int> height = new Dictionary<int, int>();
int maxHeight = -1;
List<int> heightList = new List<int>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < m; j++)
    {
        if (!height.ContainsKey(input[j]))
        {
            height.Add(input[j], 1);
            heightList.Add(input[j]);
        }
        else
        {
            height[input[j]]++;
        }
    }
}

List<int> sortedList = heightList.OrderBy(x => x * -1).ToList();
List<int> list = null;
int minTime = -1;
int resultHeight = -1;
int value = sortedList[0];

while (true)
{
    if (value < sortedList[sortedList.Count - 1])
    {
        break;
    }

    list = isImplemented(value);
    if (list[1] == -1)
    {
        value--;
        continue;
    }
    else
    {
        if (minTime == -1)
        {
            minTime = list[0];
            resultHeight = list[1];
        }
        else
        {
            if (minTime > list[0])
            {
                minTime = list[0];
                resultHeight = list[1];
            }
            else if (minTime == list[0])
            {
                resultHeight = Math.Max(resultHeight, list[1]);
            }
        }
    }

    value--;
}

Console.WriteLine($"{minTime} {resultHeight}");

List<int> isImplemented(int _height)
{
    int case1 = 0; // 블록을 뺴서 인벤토리로 넣는 경우
    int case2 = 0; // 인벤토리에서 블록을 뺴서 해당위치에 쌓는 경우

    foreach (int key in height.Keys)
    {
        if (key == _height)
        {
            continue;
        }
        else
        {
            if (key > _height)
            {
                case1 += (key - _height) * height[key];
            }
            else
            {
                case2 += (_height - key) * height[key];
            }
        }
    }

    if (case2 > b + case1)
    {
        return new List<int> { -1, -1 };
    }
    else
    {
        return new List<int> { case1 * 2 + case2, _height };
    }
}