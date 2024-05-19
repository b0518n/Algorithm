StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
int[] input = null;

TreeLevelInfo[] treeLevelInfos = new TreeLevelInfo[10];
int first = 1;
int last = 1;

for (int i = 0; i < 10; i++)
{
    treeLevelInfos[i] = new TreeLevelInfo(first, last);
    first *= 2;
    last = (last * 2) + 1;
}

int leftNumber = 0;
int rightNumber = 0;

int leftNumberLevel = 0;
int rightNumberLevel = 0;

int result = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    leftNumber = input[0];
    rightNumber = input[1];
    leftNumberLevel = GetTreeLevel(leftNumber);
    rightNumberLevel = GetTreeLevel(rightNumber);

    if (leftNumberLevel > rightNumberLevel)
    {
        AdjustLevel(ref leftNumberLevel, ref leftNumber, ref rightNumberLevel, ref rightNumber);
    }
    else if (leftNumberLevel < rightNumberLevel)
    {
        AdjustLevel(ref leftNumberLevel, ref leftNumber, ref rightNumberLevel, ref rightNumber);
    }

    result = SearchSameHighLevelValue(leftNumber, rightNumber);
    Print();
}

sw.Flush();
sw.Close();

// BinarySearch
int GetTreeLevel(int number)
{
    int left = 0;
    int right = 9;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (number >= treeLevelInfos[middle].min && number <= treeLevelInfos[middle].max)
        {
            return middle;
        }
        else if (number > treeLevelInfos[middle].max)
        {
            left = middle + 1;
        }
        else
        {
            right = middle - 1;
        }
    }

    // 주어진 문제의 범위의 숫자일 경우 이 아래부분의 코드는 실행되지 않음.
    return -1;
}

void AdjustLevel(ref int levelA, ref int a, ref int levelB, ref int b)
{
    int difference = levelA - levelB;
    if (difference > 0)
    {
        for (int i = 0; i < difference; i++)
        {
            a /= 2;
        }

        levelA -= difference;
    }
    else
    {
        for (int i = 0; i < difference * -1; i++)
        {
            b /= 2;
        }

        levelB -= difference;
    }
}
int SearchSameHighLevelValue(int numberA, int numberB)
{
    while (true)
    {
        if (numberA == numberB)
        {
            break;
        }
        else
        {
            numberA /= 2;
            numberB /= 2;
        }
    }

    return numberA;
}
void Print()
{
    sw.WriteLine(result * 10);
}

class TreeLevelInfo
{
    public int min;
    public int max;

    public TreeLevelInfo(int min, int max)
    {
        this.min = min;
        this.max = max;
    }
}