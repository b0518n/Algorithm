int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0]; // 책의 개수
int m = input[1]; // 한번에 들 수 있는 책의 개수

input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
List<int> positives = new List<int>();
List<int> negatives = new List<int>();
int result = 0;

for (int i = 0; i < n; i++)
{
    if (input[i] < 0)
    {
        negatives.Add(input[i]);
    }
    else
    {
        positives.Add(input[i]);
    }
}

if (negatives.Count != 0)
{
    negatives.Sort((x, y) =>
    {
        int compare = x.CompareTo(y) * -1;

        return compare;
    });
}
if (positives.Count != 0)
{
    positives.Sort();
}

SearchfurthestBook();

while (positives.Count > 0)
{
    if (positives.Count > m)
    {
        result += (positives[positives.Count - 1] * 2);
        for (int i = 0; i < m; i++)
        {
            positives.RemoveAt(positives.Count - 1);
        }
    }
    else
    {
        result += (positives[positives.Count - 1] * 2);
        positives = new List<int>();
    }
}

while (negatives.Count > 0)
{
    if (negatives.Count > m)
    {
        result += Math.Abs(negatives[negatives.Count - 1] * 2);
        for (int i = 0; i < m; i++)
        {
            negatives.RemoveAt(negatives.Count - 1);
        }
    }
    else
    {
        result += Math.Abs(negatives[negatives.Count - 1] * 2);
        negatives = new List<int>();
    }
}

Console.WriteLine(result);


void SearchfurthestBook()
{
    // 마지막에 처리할 책의 위치 찾기

    if (positives.Count == 0)
    {
        result -= Math.Abs(negatives[negatives.Count - 1]);
        return;
    }

    if (negatives.Count == 0)
    {
        result -= positives[positives.Count - 1];
        return;
    }

    if (positives[positives.Count - 1] >= Math.Abs(negatives[negatives.Count - 1]))
    {
        result -= positives[positives.Count - 1];
    }
    else
    {
        result -= Math.Abs(negatives[negatives.Count - 1]);
    }

    return;
}