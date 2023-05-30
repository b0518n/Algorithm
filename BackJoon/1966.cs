StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(Console.ReadLine());
int n = 0;
int m = 0;

string str = null;
int[] input = null;

List<int> queue = new List<int>();
List<int> indexQueue = new List<int>();

int count = 0;

for (int i = 0; i < t; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    n = input[0];
    m = input[1];
    str = Console.ReadLine();

    if (n == 1)
    {
        sw.WriteLine(1);
        continue;
    }

    queue = Array.ConvertAll(str.Split(), int.Parse).ToList();
    for (int j = 0; j < n; j++)
    {
        indexQueue.Add(j);
    }

    while (true)
    {
        if (queue[0] == queue.Max())
        {
            count++;
            if (indexQueue[0] == m)
            {
                sw.WriteLine(count);
                break;
            }

            queue.RemoveAt(0);
            indexQueue.RemoveAt(0);
        }
        else
        {
            queue.Add(queue[0]);
            indexQueue.Add(indexQueue[0]);
            queue.RemoveAt(0);
            indexQueue.RemoveAt(0);
        }
    }

    queue.Clear();
    indexQueue.Clear();
    count = 0;
}

sw.Close();