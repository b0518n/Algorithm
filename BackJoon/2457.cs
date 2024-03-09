StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = null;
List<DateInfo> list = new List<DateInfo>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    list.Add(new DateInfo(input[0], input[1], input[2], input[3]));
}

list.Sort((x, y) =>
{
    int compare = x.startIndex.CompareTo(y.startIndex);
    if (compare == 0)
    {
        compare = x.endIndex.CompareTo(y.endIndex) * -1;
    }

    return compare;
});

int cnt = 0;
int index = 0;

int startIndex = 0;
int endIndex = 0;

int tempStartIndex = 0;
int tempEndIndex = 0;

while (true)
{
    if (index == list.Count)
    {
        if (tempStartIndex != 0 || tempEndIndex != 0)
        {
            startIndex = Math.Min(startIndex, tempStartIndex);
            endIndex = tempEndIndex;
            cnt++;
        }

        break;
    }

    if (endIndex >= 333)
    {
        if (cnt == 0)
        {
            cnt++;
        }

        break;
    }

    if (cnt == 0)
    {
        if (list[index].startIndex <= 59 && list[index].endIndex >= 59)
        {
            if (startIndex == 0 && endIndex == 0)
            {
                startIndex = list[index].startIndex;
                endIndex = list[index].endIndex;
                index++;
            }
            else
            {
                if (endIndex >= list[index].endIndex)
                {
                    index++;
                }
                else
                {
                    startIndex = list[index].startIndex;
                    endIndex = list[index].endIndex;
                    index++;
                }
            }
        }
        else
        {
            if (startIndex == 0 && endIndex == 0)
            {
                index++;
            }
            else
            {
                cnt++;
            }
        }
    }
    else
    {
        if (list[index].startIndex <= endIndex + 1)
        {
            if (tempStartIndex == 0 && tempEndIndex == 0)
            {
                tempStartIndex = list[index].startIndex;
                tempEndIndex = list[index].endIndex;
                index++;
            }
            else
            {
                if (tempEndIndex >= list[index].endIndex)
                {
                    index++;
                }
                else
                {
                    tempStartIndex = list[index].startIndex;
                    tempEndIndex = list[index].endIndex;
                    index++;
                }
            }
        }
        else
        {
            if (tempStartIndex == 0 && tempEndIndex == 0)
            {
                index++;
            }
            else
            {
                cnt++;
                startIndex = Math.Min(startIndex, tempStartIndex);
                endIndex = tempEndIndex;
                tempStartIndex = 0;
                tempEndIndex = 0;
            }
        }
    }
}

if (!(startIndex <= 59 && endIndex >= 333))
{
    cnt = 0;
}

sw.WriteLine(cnt);
sw.Flush();
sw.Close();

class DateInfo
{
    public static int[] arr = new int[13] { 0, 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
    public int startIndex = 0;
    public int endIndex = 0;

    public DateInfo(int startMonth, int startDay, int endMonth, int endDay)
    {
        if (endDay == 0)
        {
            endMonth -= 1;
            switch (endMonth)
            {
                case 4:
                    endDay = 30;
                    break;
                case 6:
                    endDay = 30;
                    break;
                case 9:
                    endDay = 30;
                    break;
                case 11:
                    endDay = 30;
                    break;
                case 1:
                    endDay = 31;
                    break;
                case 3:
                    endDay = 31;
                    break;
                case 5:
                    endDay = 31;
                    break;
                case 7:
                    endDay = 31;
                    break;
                case 8:
                    endDay = 31;
                    break;
                case 10:
                    endDay = 31;
                    break;
                case 12:
                    endDay = 31;
                    break;
                case 2:
                    endDay = 28;
                    break;
            }
        }
        else
        {
            endDay -= 1;
        }

        startIndex = arr[startMonth] + startDay - 1;
        endIndex = arr[endMonth] + endDay - 1;
    }
}