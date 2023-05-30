StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
List<int> deque = new List<int>();
string str = null;
string[] temp = null;

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    if (str[0] == 'p') // push_back, push_front, pop_front, pop_back
    {
        if (str[1] == 'u') // push_back, push_front
        {
            temp = str.Split();

            if (str[5] == 'b') // push_back
            {
                deque.Add(int.Parse(temp[1]));
            }
            else // push_front
            {
                deque = PushFront(deque, int.Parse(temp[1]));
            }
        }
        else // pop_front, pop_back
        {
            if (str[4] == 'f') // pop_front
            {
                if (deque.Count == 0)
                {
                    sw.WriteLine(-1);
                }
                else
                {
                    sw.WriteLine(deque[0]);
                    deque.RemoveAt(0);
                }
            }
            else // pop_back
            {
                if (deque.Count == 0)
                {
                    sw.WriteLine(-1);
                }
                else
                {
                    sw.WriteLine(deque[deque.Count - 1]);
                    deque.RemoveAt(deque.Count - 1);
                }
            }
        }
    }
    else if (str[0] == 'f') // front
    {
        if (deque.Count == 0)
        {
            sw.WriteLine(-1);
        }
        else
        {
            sw.WriteLine(deque[0]);
        }
    }
    else if (str[0] == 'b') // back
    {
        if (deque.Count == 0)
        {
            sw.WriteLine(-1);
        }
        else
        {
            sw.WriteLine(deque[deque.Count - 1]);
        }
    }
    else if (str[0] == 'e') // empty
    {
        sw.WriteLine(deque.Count == 0 ? 1 : 0);
    }
    else // size
    {
        sw.WriteLine(deque.Count);
    }
}

sw.Close();

List<int> PushFront(List<int> list, int value)
{
    List<int> temp = new List<int>();
    temp.Add(value);

    foreach (int tmp in list)
    {
        temp.Add(tmp);
    }

    return temp;
}