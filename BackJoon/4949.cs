StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int input = 0;
List<int> list = new List<int>();
List<int> list1 = new List<int>();
List<string> list2 = new List<string>();
for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    list.Add(input);
}

int index = 0;
for (int i = 1; i < n + 1; i++)
{
    if (list1.Count == 0)
    {
        list1.Add(i);
        list2.Add("+");
    }
    else
    {
        while (true)
        {
            if (list1.Count == 0)
            {
                break;
            }

            if (list[index] == list1[list1.Count - 1])
            {
                list1.RemoveAt(list1.Count - 1);
                list2.Add("-");
                index++;
            }
            else
            {
                list1.Add(i);
                list2.Add("+");
                break;
            }
        }
    }

}

bool flag = false;
while (true)
{
    if (list1.Count == 0)
    {
        break;
    }

    if (list[index] != list1[list1.Count - 1])
    {
        flag = true;
        break;
    }
    else
    {
        index++;
        list1.RemoveAt(list1.Count - 1);
        list2.Add("-");
    }
}

if (flag == true)
{
    sw.WriteLine("NO");
}
else
{
    for (int i = 0; i < list2.Count; i++)
    {
        sw.WriteLine(list2[i]);
    }
}

sw.Close();