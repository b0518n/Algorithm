StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
List<int> queue = new List<int>();
string input = null;
string[] temp = null;

for (int i = 0; i < n; i++)
{
    input = Console.ReadLine();
    if (input[0] == 'p') // push, pop
    {
        if (input[1] == 'u') // push
        {
            temp = input.Split();
            queue.Add(int.Parse(temp[1]));
        }
        else // pop
        {
            if (queue.Count == 0)
            {
                sw.WriteLine(-1);
            }
            else
            {
                sw.WriteLine(queue[0]);
                queue.RemoveAt(0);
            }
        }
    }
    else if (input[0] == 'f') // front
    {
        if (queue.Count == 0)
        {
            sw.WriteLine(-1);
        }
        else
        {
            sw.WriteLine(queue[0]);
        }
    }
    else if (input[0] == 'b') // back
    {
        if (queue.Count == 0)
        {
            sw.WriteLine(-1);
        }
        else
        {
            sw.WriteLine(queue[queue.Count - 1]);
        }
    }
    else if (input[0] == 's') // size
    {
        sw.WriteLine(queue.Count);
    }
    else if (input[0] == 'e') // empty
    {
        if (queue.Count == 0)
        {
            sw.WriteLine(1);
        }
        else
        {
            sw.WriteLine(0);
        }
    }
}

sw.Close();