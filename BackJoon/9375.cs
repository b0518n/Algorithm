StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int t = int.Parse(Console.ReadLine());
Dictionary<string, int> dic = new Dictionary<string, int>();
for (int i = 0; i < t; i++)
{
    int n = int.Parse(Console.ReadLine());
    for (int j = 0; j < n; j++)
    {
        string[] str = Console.ReadLine().Split(" ");
        string a = str[0];
        string b = str[1];

        if (dic.Count == 0)
        {
            dic.Add(b, 1);
        }
        else
        {
            if (dic.ContainsKey(b))
            {
                dic[b] += 1;
            }
            else
            {
                dic.Add(b, 1);
            }
        }

    }


    int value = 0;
    // 종류가 1가지 일경우는 무조건 하나를 골라야 되기 때문에,
    // n개 일경우 nC1 = n이므로 개수만큼을 value에 넣었음.
    if (dic.Keys.Count == 1)
    {
        foreach (string tmp in dic.Keys)
        {
            value += (dic[tmp]);
        }
    }
    else
    // 종류가 여러가지 일경우
    // 예를 들어 headgear : 2, eyewear : 3, face : 4 인 상황인 경우,
    // headgear는 2개 중 하나를 고르거나 안 고르는 경우 : 3
    // eyewear : 4
    // face : 5
    // 즉 3 * 4 * 5 = 60인데 모두 안고르는 경우 1를 빼는 방식을 사용함.
    {
        value = 1;
        foreach (string tmp in dic.Keys)
        {
            value *= (dic[tmp] + 1);
        }
        value -= 1;
    }
    sw.WriteLine(value);
    dic.Clear();
}

sw.Close();
