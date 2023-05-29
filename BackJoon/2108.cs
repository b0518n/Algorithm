StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int input = 0;
double sum = 0;
int maxCount = 0;
List<int> list = new List<int>();
Dictionary<int, int> dic = new Dictionary<int, int>();
for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    sum += input;
    list.Add(input);
    if (dic.ContainsKey(input))
    {
        dic[input]++;
        if (maxCount < dic[input])
        {
            maxCount = dic[input];
        }
    }
    else
    {
        if (i == 0)
        {
            maxCount = 1;
        }

        dic.Add(input, 1);
    }
}

List<int> tmp = new List<int>();

foreach (int i in dic.Keys)
{
    if (dic[i] == maxCount)
    {
        tmp.Add(i);
    }
}

tmp.Sort();

list.Sort();
int avg = (int)Math.Round(sum / n, 0);
int middle = list[(list.Count - 1) / 2];
int range = list[list.Count - 1] - list[0];

sw.WriteLine(avg);
sw.WriteLine(middle);
sw.WriteLine(tmp.Count > 1 ? tmp[1] : tmp[0]);
sw.WriteLine(range);

sw.Close();