int n = int.Parse(Console.ReadLine());
int[] input = null;
List<int[]> list = new List<int[]>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list.Add(new int[2] { input[0], input[1] });
}

list.Sort((x, y) =>
{
    int compare = x[0].CompareTo(y[0]) * -1;
    return compare;
});

Dictionary<int, int> schedule = new Dictionary<int, int>();
int result = 0;

for (int i = 0; i < n; i++)
{
    if (!schedule.ContainsKey(list[i][1]))
    {
        result += list[i][0];
        schedule.Add(list[i][1], list[i][0]);
    }
    else
    {
        int day = list[i][1];
        while (true)
        {
            if (schedule.ContainsKey(day))
            {
                if (day == 1)
                {
                    break;
                }
                else
                {
                    day--;
                }
            }
            else
            {
                result += list[i][0];
                schedule.Add(day, list[i][0]);
                break;
            }
        }
    }
}

Console.WriteLine(result);