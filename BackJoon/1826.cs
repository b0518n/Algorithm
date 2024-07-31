StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = null;
List<Info> list = new List<Info>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    list.Add(new Info(input[0], input[1]));
}

input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int finalDest = input[0];
int oil = input[1];

list.Sort((x, y) => x.dest.CompareTo(y.dest));
int index = 0;
int result = 0;

MyHeap pq = new MyHeap();
Info temp = null;

while (true)
{
    if (oil >= finalDest)
    {
        sw.WriteLine(result);
        break;
    }

    for (int i = index; i < list.Count; i++)
    {
        if (list[i].dest > oil)
        {
            index = i;
            break;
        }
        else
        {
            pq.Push(new Info(list[i].dest, list[i].oil));
            index = i + 1;
        }


    }

    if (pq.count == 0)
    {
        if (oil >= finalDest)
        {
            sw.WriteLine(result);
        }
        else
        {
            sw.WriteLine(-1);
        }

        break;
    }

    temp = pq.Peek();
    pq.Pop();
    result++;

    oil += temp.oil;
}

sw.Flush();
sw.Close();

class Info
{
    public int dest;
    public int oil;

    public Info(int _dest, int _oil)
    {
        this.dest = _dest;
        this.oil = _oil;
    }
}

class MyHeap
{
    public List<Info> container;
    public int count;

    public MyHeap()
    {
        this.container = new List<Info>();
        this.count = 0;
    }

    public void Push(Info _info)
    {
        this.container.Add(_info);
        count++;
        HeapifyUp(count - 1);
    }

    public void Pop()
    {
        Swap(0, count - 1);
        container.RemoveAt(count - 1);
        count--;
        HeapifyDown(0);
    }

    public Info Peek()
    {
        return container[0];
    }

    public void HeapifyUp(int _index)
    {
        int parentIndex = (_index - 1) / 2;

        while (parentIndex != _index)
        {
            if (container[parentIndex].oil < container[_index].oil)
            {
                Swap(parentIndex, _index);
                _index = parentIndex;
                parentIndex = (parentIndex - 1) / 2;
            }
            else if (container[parentIndex].oil == container[_index].oil)
            {
                if (container[parentIndex].dest > container[_index].dest)
                {
                    Swap(parentIndex, _index);
                    _index = parentIndex;
                    parentIndex = (parentIndex - 1) / 2;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }

    public void HeapifyDown(int _index)
    {
        int index = _index;
        int leftChildIndex = 2 * _index + 1;
        int rightChildIndex = 2 * _index + 2;

        if (leftChildIndex <= count - 1 && (container[leftChildIndex].oil > container[index].oil || (container[leftChildIndex].oil == container[index].oil && container[leftChildIndex].dest < container[index].dest)))
        {
            index = leftChildIndex;
        }

        if (rightChildIndex <= count - 1 && (container[rightChildIndex].oil > container[index].oil || (container[rightChildIndex].oil == container[index].oil && container[rightChildIndex].dest < container[index].dest)))
        {
            index = rightChildIndex;
        }

        if (index != _index)
        {
            Swap(index, _index);
            HeapifyDown(index);
        }
    }

    public void Swap(int _index1, int _index2)
    {
        Info temp = container[_index1];
        container[_index1] = container[_index2];
        container[_index2] = temp;
    }
}