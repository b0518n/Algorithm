int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int f = input[0];
int s = input[1];
int g = input[2];

int u = input[3];
int d = input[4];

Dictionary<int, int> dics = new Dictionary<int, int>();
BFS(s);

if (dics.ContainsKey(g))
{
    Console.WriteLine(dics[g]);
}
else
{
    Console.WriteLine("use the stairs");
}

void BFS(int index)
{
    Queue<int> queue = new Queue<int>();
    queue.Enqueue(index);
    dics.Add(index, 0);

    int temp = 0;
    int _index = 0;

    while (queue.Count > 0)
    {
        temp = queue.Dequeue();
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                _index = temp + u;
            }
            else
            {
                _index = temp - d;
            }

            if (_index <= 0 || _index > f)
            {
                continue;
            }


            if (dics.ContainsKey(_index))
            {
                if (dics[_index] > dics[temp] + 1)
                {
                    dics[_index] = dics[temp] + 1;
                    queue.Enqueue(_index);
                }
            }
            else
            {
                dics.Add(_index, dics[temp] + 1);
                queue.Enqueue(_index);
            }
        }
    }
}