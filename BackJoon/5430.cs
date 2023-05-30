StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
string str = null;
int n = 0;
LinkedList<int> deque = new LinkedList<int>();
int[] temp = null;
string input = null;
int count = 0;

for (int i = 0; i < t; i++)
{
    deque.Clear();
    count = 0;
    str = Console.ReadLine();
    n = int.Parse(Console.ReadLine());
    input = Console.ReadLine();
    if (n == 0)
    {
        temp = new int[0];
    }
    else
    {
        temp = Array.ConvertAll(input.Replace('[', ',').Replace(']', ',').Trim(',').Split(','), int.Parse);
    }

    foreach (int x in temp)
    {
        deque.AddLast(x);
    }

    for (int j = 0; j < str.Length; j++)
    {
        if (str[j] == 'R')
        {
            count++;
        }
        else
        {
            if (deque.Count == 0)
            {
                sw.WriteLine("error");
                break;
            }

            if (count % 2 == 0)
            {
                deque.RemoveFirst();
            }
            else
            {
                deque.RemoveLast();
            }


        }

        if (j == str.Length - 1)
        {
            temp = deque.ToArray();

            if (count % 2 != 0)
            {
                Array.Reverse(temp);
            }

            if (temp.Length == 0)
            {
                sw.WriteLine("[]");
            }
            else if (temp.Length == 1)
            {
                sw.WriteLine($"[{temp[0]}]");
            }
            else
            {
                for (int k = 0; k < temp.Length; k++)
                {
                    if (k == 0)
                    {
                        sw.Write($"[{temp[k]},");
                    }
                    else if (k == temp.Length - 1)
                    {
                        sw.WriteLine($"{temp[k]}]");
                    }
                    else
                    {
                        sw.Write($"{temp[k]},");
                    }
                }
            }
        }
    }
}
sw.Close();