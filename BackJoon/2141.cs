StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = null;
List<Info> list = new List<Info>();
long total = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    list.Add(new Info(input[0], input[1]));
    total += (long)input[1];
}

list.Sort((x, y) => x.dest.CompareTo(y.dest));
long cnt = 0;

for (int i = 0; i < n; i++)
{
    cnt += list[i].cnt;
    if (cnt >= (total + 1) / 2)
    {
        sw.WriteLine(list[i].dest);
        break;
    }
}

sw.Flush();
sw.Close();

class Info
{
    public long dest;
    public long cnt;

    public Info(long _dest, long _cnt)
    {
        this.dest = _dest;
        this.cnt = _cnt;
    }
}