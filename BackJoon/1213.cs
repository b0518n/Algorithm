using System.Numerics;

string input = Console.ReadLine();
int length = input.Length;
string[] arr = new string[length];
Dictionary<string, int> dics = new Dictionary<string, int>();
string result = null;
string[] _arr = new string[length];

void Solve()
{
    arr = arr.ToHashSet().ToArray();
    Array.Sort(arr);
    Queue<string> queue = new Queue<string>();
    for (int i = 0; i < arr.Length; i++)
    {
        queue.Enqueue(arr[i]);
    }

    string temp = null;
    int start = 0;
    int end = length - 1;
    int mid = (start + end) / 2;
    bool flag = false; // 홀수 개인 알파벳 처리가 될경우 true 설정
    if (length % 2 == 0)
    {
        flag = true;
    }

    while (true)
    {
        if (start >= end && flag == true)
        {
            break;
        }

        temp = queue.First();

        if (dics[temp] % 2 == 0)
        {
            _arr[start] = temp;
            _arr[end] = temp;
            start++;
            end--;
            dics[temp] -= 2;
            if (dics[temp] == 0)
            {
                queue.Dequeue();
            }
        }
        else
        {
            flag = true;
            _arr[mid] = temp;
            dics[temp]--;
            if (dics[temp] == 0)
            {
                queue.Dequeue();
            }
        }

    }

    result = string.Join("", _arr);
}

for (int i = 0; i < length; i++)
{
    arr[i] = input[i].ToString();
    if (dics.ContainsKey(arr[i]))
    {
        dics[arr[i]]++;
    }
    else
    {
        dics.Add(arr[i], 1);
    }
}

if (length % 2 == 0)
{
    foreach (string key in dics.Keys)
    {
        if (dics[key] % 2 == 1)
        {
            result = "I'm Sorry Hansoo";
            break;
        }
    }

    if (result == null)
    {
        Solve();
    }

}
else
{
    int count = 0;

    foreach (string key in dics.Keys)
    {
        if (dics[key] % 2 == 1)
        {
            count++;
        }

        if (count >= 2)
        {
            result = "I'm Sorry Hansoo";
            break;
        }
    }

    if (result == null)
    {
        Solve();
    }
}

Console.WriteLine(result);
