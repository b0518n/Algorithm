int n = int.Parse(Console.ReadLine());
int input = 0;
int min = 0;
int max = 0;
int previousValue = 0;
List<int> list = new List<int>();
Dictionary<int, int> dic = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    dic.Add(input, 1);
    if (i == 0)
    {
        min = input;
    }

    if (i == n - 1)
    {
        max = input;
    }

    if (i != 0)
    {
        list.Add(input - previousValue);
    }

    previousValue = input;

}

List<int,list> list1 = list.Clone().ToHashSet().ToList();
int difference = list[0];
for (int i = 1; i < list.Count; i++)
{
    difference = GCD(difference, list[i]);
}



int GCD(int x, int y)
{
    int first = 0;
    int second = 0;
    if (x > y)
    {
        first = x;
        second = y;
    }
    else
    {
        first = y;
        second = x;
    }

    if (second == 0)
    {
        return first;
    }

    return GCD(second, first % second);

}