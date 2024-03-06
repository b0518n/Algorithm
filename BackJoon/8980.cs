StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int c = input[1];
int m = int.Parse(sr.ReadLine());
List<BoxInfo> list = new List<BoxInfo>();

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    list.Add(new BoxInfo(input[0], input[1], input[2]));
}

list.Sort((x, y) =>
{
    int compare = x.end.CompareTo(y.end);

    if (compare == 0)
    {
        compare = x.start.CompareTo(y.start);
    }

    return compare;
});

int[] arr = new int[n + 1];
int start = 0;
int end = 0;
int cnt = 0;
int result = 0;


for (int i = 0; i < m; i++)
{
    start = list[i].start;
    end = list[i].end;
    cnt = list[i].cnt;

    bool isPassible = true;
    int min = int.MaxValue;

    for (int j = start; j < end; j++)
    {
        if (arr[j] >= c)
        {
            isPassible = false;
            break;
        }
        else
        {
            min = Math.Min(min, c - arr[j]);
        }
    }

    if (isPassible)
    {
        min = Math.Min(min, cnt);
        result += min;

        for (int j = start; j < end; j++)
        {
            arr[j] += min;
        }
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

class BoxInfo
{
    public int start;
    public int end;
    public int cnt;

    public BoxInfo(int start, int end, int cnt)
    {
        this.start = start;
        this.end = end;
        this.cnt = cnt;
    }
}