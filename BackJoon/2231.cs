// 풀이 1
int n = int.Parse(Console.ReadLine());

int[] arr = new int[1000054];
arr[0] = -1;
int index = 0;

for (int i = 1; i < 1000001; i++)
{
    if (i >= 1 && i < 10)
    {
        index = i + i;
        Add(index, i);
    }
    else if (i >= 10 && i < 100)
    {
        index = i + i / 10 + i % 10;
        Add(index, i);
    }
    else if (i >= 100 && i < 1000)
    {
        index = i + i / 100 + (i % 100) / 10 + i % 10;
        Add(index, i);
    }
    else if (i >= 1000 && i < 10000)
    {
        index = i + i / 1000 + (i % 1000) / 100 + (i % 100) / 10 + i % 10;
        Add(index, i);
    }
    else if (i >= 10000 && i < 100000)
    {
        index = i + i / 10000 + (i % 10000) / 1000 + (i % 1000) / 100 + (i % 100) / 10 + i % 10;
        Add(index, i);
    }
    else if (i >= 100000 && i < 1000000)
    {
        index = i + i / 100000 + (i % 100000) / 10000 + (i % 10000) / 1000 + (i % 1000) / 100 + (i % 100) / 10 + i % 10;
        Add(index, i);
    }
    else
    {
        Add(1000001, 1000000);
    }
}

void Add(int index, int value)
{
    if (arr[index] == 0)
    {
        arr[index] = value;
    }
}

Console.WriteLine(arr[n]);


//풀이 2
/*
int n = int.Parse(Console.ReadLine());
int[] arr = new int[1000054];
arr[0] = -1;
int index = 0;
string tmp = string.Empty;
for (int i = 1; i < 1000001; i++)
{
    if (i >= 1 && i < 10)
    {
        index = i + i;
        Add(index, i);
    }
    else
    {
        index = i;
        tmp = i.ToString();
        for (int j = 0; j < tmp.Length; j++)
        {
            index += int.Parse(tmp[j].ToString());
        }
        Add(index, i);
    }
}
void Add(int index, int value)
{
    if (arr[index] == 0)
    {
        arr[index] = value;
    }
}
Console.WriteLine(arr[n]);
*/