List<int[]> list = new List<int[]>();
int n = int.Parse(Console.ReadLine());

int[] input = null;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list.Add(new int[2] { input[0], input[1] });
}

list.Sort((x, y) =>
{
    int compare = x[1].CompareTo(y[1]) * -1;
    if (compare == 0)
    {
        compare = x[0].CompareTo(y[0]);
    }

    return compare;
});

int score = 0;
Dictionary<int, int> dics = new Dictionary<int, int>();

for (int i = 0; i < list.Count; i++)
{
    if (!dics.ContainsKey(list[i][0]))
    {
        dics.Add(list[i][0], list[i][1]);
        score += list[i][1];
    }
    else
    {
        int day = SearchDay(list[i][0]);
        if (day == -1)
        {
            continue;
        }
        else
        {
            dics.Add(day, list[i][1]);
            score += list[i][1];
        }
    }
}

Console.WriteLine(score);

int SearchDay(int day)
{
    int _day = day - 1;

    while (true)
    {
        if (_day <= 0)
        {
            return -1;
        }

        if (dics.ContainsKey(_day))
        {
            _day--;
        }
        else
        {
            return _day;
        }
    }
}