StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] ngfs = new int[n];
List<int> stack = new List<int>();
Dictionary<int, int> dic = new Dictionary<int, int>();

for (int i = 0; i < n; i++)
{
    ngfs[i] = -1;
    if (dic.ContainsKey(arr[i]))
    {
        dic[arr[i]]++;
    }
    else
    {
        dic.Add(arr[i], 1);
    }
}

// 스택안에 값을 넣는 것이 아닌 인덱스를 넣는 것이 알고리즘 풀이에 유리한 것 같음.
for (int i = 0; i < n; i++)
{
    while (stack.Count != 0 && dic[arr[stack[stack.Count - 1]]] < dic[arr[i]])
    {
        ngfs[stack[stack.Count - 1]] = arr[i];
        stack.RemoveAt(stack.Count - 1);
    }

    stack.Add(i);
}


for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        sw.Write(ngfs[i]);
    }
    else
    {
        sw.Write(" " + ngfs[i]);
    }
}

sw.Flush();
sw.Close();