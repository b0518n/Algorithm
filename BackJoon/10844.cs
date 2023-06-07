int n = int.Parse(Console.ReadLine());
int result = 0;
long[] arr = new long[101];
Dictionary<int, int> dic = new Dictionary<int, int>();
Dictionary<int, int> tempDic = new Dictionary<int, int>();

arr[1] = 9;
for (int i = 0; i <= 9; i++)
{
    if (i == 0)
    {
        dic.Add(i, 0);
    }
    else
    {
        dic.Add(i, 1);
    }

    tempDic.Add(i, 0);
}

for (int i = 2; i < 101; i++)
{
    foreach (int temp in dic.Keys)
    {
        int key1 = temp + 1;
        int key2 = temp - 1;
        int value = dic[temp] % 1000000000;

        if (temp == 0)
        {
            arr[i] += value;
            tempDic[key1] += value;
        }
        else if (temp == 9)
        {
            arr[i] += value;
            tempDic[key2] += value;
        }
        else
        {
            arr[i] += (value * 2);
            tempDic[key1] += value;
            tempDic[key2] += value;
        }
    }

    dic = Copy(tempDic);
    Clear(tempDic);
}

Console.WriteLine(arr[n] % 1000000000);

Dictionary<int, int> Copy(Dictionary<int, int> dic)
{
    Dictionary<int, int> temp = new Dictionary<int, int>();
    foreach (int tmp in dic.Keys)
    {
        temp.Add(tmp, dic[tmp]);
    }

    return temp;
}

void Clear(Dictionary<int, int> dic)
{
    foreach (int temp in dic.Keys)
    {
        dic[temp] = 0;
    }
}