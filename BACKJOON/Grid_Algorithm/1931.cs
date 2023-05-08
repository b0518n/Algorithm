int n = int.Parse(Console.ReadLine());
int[] input;
List<int[]> list = new List<int[]>();
int count = 0;
int start = 0;
int end = 0;

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    list.Add(input);
}

list.Sort((x, y) =>
{
    // 회의가 끝나는 시간을 기준으로 오름차순 정렬, 만약 끝나는 시간이 동일할 경우 회의가 시작하는 시간을 기준으로 오름차순 정렬
    int compareResult = x[1].CompareTo(y[1]);
    if (compareResult == 0)
    {
        compareResult = x[0].CompareTo(y[0]);
    }

    return compareResult;
});

for (int i = 0; i < n; i++)
{
    if (count == 0)
    {
        count++;
        start = list[i][0];
        end = list[i][1];
    }
    else
    {
        if (list[i][0] >= end)
        {
            count++;
            start = list[i][0];
            end = list[i][1];
        }
        else
        {
            continue;
        }
    }
}

Console.WriteLine(count);