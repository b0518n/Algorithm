StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
int[] input = null;
int n = 0;
int m = 0;

List<StudentInfo> list = new List<StudentInfo>();
int[] dp = null;
int cnt = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    n = input[0];
    m = input[1];

    list.Clear();
    dp = new int[1001];
    cnt = 0;

    for (int j = 0; j < m; j++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        list.Add(new StudentInfo(input[0], input[1]));
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

    for (int k = 0; k < list.Count; k++)
    {
        for (int l = list[k].start; l < list[k].end + 1; l++)
        {
            if (dp[l] == 0)
            {
                dp[l] = 1;
                cnt++;
                break;
            }
        }
    }

    sw.WriteLine(cnt);
}

sw.Flush();
sw.Close();

class StudentInfo
{
    public int start;
    public int end;

    public StudentInfo(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}