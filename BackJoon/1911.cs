StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int n = 0;
int l = 0;

List<PuddleInfo> puddles = new List<PuddleInfo>();

Input();
puddles.Sort((x, y) => x.start.CompareTo(y.start));
int result = BuildBridge();
Print();

void Input()
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    l = input[1];

    for (int i = 0; i < n; i++)
    {
        input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        puddles.Add(new PuddleInfo(input[0], input[1]));
    }
}
int BuildBridge()
{
    int pos = 0;
    int cnt = 0;

    for (int i = 0; i < n; i++)
    {
        if (pos < puddles[i].start)
        {
            pos = puddles[i].start;
        }

        while (pos < puddles[i].end)
        {
            pos += l;
            cnt++;
        }
    }

    return cnt;
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}

class PuddleInfo
{
    public int start;
    public int end;

    public PuddleInfo(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}