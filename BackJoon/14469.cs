StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

List<CowInfo> list = new List<CowInfo>();

int n = int.Parse(sr.ReadLine());
int[] input = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    list.Add(new CowInfo(input[0], input[1]));
}

list.Sort((x, y) =>
{
    int compare = x.arrivedTime.CompareTo(y.arrivedTime);

    if (compare == 0)
    {
        compare = x.consumedTime.CompareTo(y.consumedTime);
    }

    return compare;
});

int currentTime = 0;
int index = 0;

while (index <= list.Count - 1)
{
    if (currentTime <= list[index].arrivedTime)
    {
        currentTime = list[index].arrivedTime;
    }

    currentTime += list[index].consumedTime;
    index++;
}

sw.WriteLine(currentTime);
sw.Flush();
sw.Close();

class CowInfo
{
    public int arrivedTime;
    public int consumedTime;

    public CowInfo(int arrivedTime, int consumedTime)
    {
        this.arrivedTime = arrivedTime;
        this.consumedTime = consumedTime;
    }
}