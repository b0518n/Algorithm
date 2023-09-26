int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int l = input[0];
int c = input[1];
string[] arr = Console.ReadLine().Split();
List<string> temp = new List<string>();
List<string> resultList = new List<string>();
StringBuilder sb = new StringBuilder();
Recursion(0, 0, -1);
resultList.Sort();
for (int i = 0; i < resultList.Count; i++)
{
    sb.AppendLine(resultList[i]);
}

Console.WriteLine(sb.ToString());


void Recursion(int vCnt, int cCnt, int index)
{
    if (vCnt + cCnt == l)
    {
        if (vCnt >= 1 && cCnt >= 2)
        {
            List<string> _temp = CopyList();
            _temp.Sort();
            resultList.Add(string.Join("", _temp));
        }

        return;
    }

    for (int i = index + 1; i < c; i++)
    {
        string str = arr[i];
        if (str == "a" || str == "e" || str == "i" || str == "o" || str == "u")
        {
            temp.Add(str);
            Recursion(vCnt + 1, cCnt, i);
            temp.RemoveAt(temp.Count - 1);
        }
        else
        {
            temp.Add(str);
            Recursion(vCnt, cCnt + 1, i);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}

List<string> CopyList()
{
    List<string> list = new List<string>();

    for (int i = 0; i < temp.Count; i++)
    {
        list.Add(temp[i]);
    }

    return list;
}