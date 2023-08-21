using (StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()))
using (StreamReader sr = new StreamReader(Console.OpenStandardInput()))
{
    int n = 0;
    int[] line = null;
    Stack<int> space = new Stack<int>();
    n = int.Parse(sr.ReadLine());
    line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

    int number = 1;
    int index = 0;
    int previousNumber = 0;
    int previousIndex = 0;

    while (true)
    {
        previousNumber = number;
        previousIndex = index;

        if (space.Count != 0)
        {
            if (space.Peek() == number)
            {
                number++;
                space.Pop();
                continue;
            }
        }

        if (index <= n - 1)
        {
            if (line[index] == number)
            {
                index++;
                number++;
            }
            else
            {
                space.Push(line[index]);
                index++;
            }
        }

        if (previousNumber == number && previousIndex == index)
        {
            break;
        }

    }

    if (space.Count == 0)
    {
        sw.Write("Nice");
    }
    else
    {
        sw.Write("Sad");
    }

    sw.Flush();
    sw.Close();
}