StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
string input = string.Empty;

int[,] map = new int[n, n];
Dictionary<string, int> mirrorDic = new Dictionary<string, int>();
PosInfo start = null;
PosInfo end = null;

for (int i = 0; i < n; i++)
{
    input = sr.ReadLine();
    for (int j = 0; j < n; j++)
    {
        if (input[j].ToString() == "*")
        {
            map[i, j] = -1;
        }
        else if (input[j].ToString() == ".")
        {
            map[i, j] = int.MaxValue;
        }
        else if (input[j].ToString() == "#")
        {
            if (start == null)
            {
                start = new PosInfo(i, j);
                map[i, j] = 0;
            }
            else
            {
                end = new PosInfo(i, j);
                map[i, j] = int.MaxValue;
            }
        }
        else if (input[j].ToString() == "!")
        {
            map[i, j] = int.MaxValue;
            mirrorDic.Add($"{i} {j}", 1);
        }
    }
}

int[,] visited = new int[n, n];

// 왼 : 0, 오 : 1, 위 : 2, 밑 : 3, 
int[] dy = new int[4] { 0, 0, -1, 1 };
int[] dx = new int[4] { -1, 1, 0, 0 };

GetMirrorCnt();

sw.WriteLine(map[end.y, end.x]);
sw.Flush();
sw.Close();


void GetMirrorCnt()
{
    MinHeap pq = new MinHeap();
    pq.Push(start.y, start.x, 0, -1);

    MirrorInfo temp = null;
    int ny = 0;
    int nx = 0;

    while (pq.count > 0)
    {
        temp = pq.Peek();
        pq.Pop();

        if (visited[temp.y, temp.x] == 1)
            continue;

        visited[temp.y, temp.x] = 1;


        if (map[temp.y, temp.x] != temp.cnt)
            continue;

        if (temp.direction == -1) // 처음 문의 위치
        {
            for (int i = 0; i < 4; i++)
            {
                int k = 1;
                while (true)
                {
                    ny = temp.y + dy[i] * k;
                    nx = temp.x + dx[i] * k;

                    if (ny < 0 || nx < 0 || ny >= n || nx >= n)
                        break;
                    if (map[ny, nx] == -1)
                        break;

                    if (mirrorDic.ContainsKey($"{ny} {nx}"))
                    {
                        if (visited[ny, nx] == 0)
                        {
                            pq.Push(ny, nx, temp.cnt, i);
                        }
                    }

                    if (map[ny, nx] == int.MaxValue)
                    {
                        map[ny, nx] = temp.cnt;
                    }
                    else
                    {
                        map[ny, nx] = Math.Min(map[ny, nx], temp.cnt);
                    }

                    k++;
                }
            }
        }
        else
        {
            if (mirrorDic.ContainsKey($"{temp.y} {temp.x}")) // 거울을 설치할 수 있는 위치
            {
                for (int i = 0; i < 4; i++)
                {
                    int k = 1;
                    while (true)
                    {
                        ny = temp.y + dy[i] * k;
                        nx = temp.x + dx[i] * k;

                        if (ny < 0 || nx < 0 || ny >= n || nx >= n)
                            break;
                        if (map[ny, nx] == -1)
                            break;

                        if (mirrorDic.ContainsKey($"{ny} {nx}"))
                        {
                            if (visited[ny, nx] == 0)
                            {
                                if (i == temp.direction)
                                {
                                    pq.Push(ny, nx, temp.cnt, i);
                                }
                                else
                                {
                                    pq.Push(ny, nx, temp.cnt + 1, i);
                                }
                            }
                        }

                        if (map[ny, nx] == int.MaxValue)
                        {
                            if (i == temp.direction)
                            {
                                map[ny, nx] = temp.cnt;
                            }
                            else
                            {
                                map[ny, nx] = temp.cnt + 1;
                            }
                        }
                        else
                        {
                            if (i == temp.direction)
                            {
                                if (map[ny, nx] > temp.cnt)
                                {
                                    map[ny, nx] = temp.cnt;
                                }
                            }
                            else
                            {
                                if (map[ny, nx] > temp.cnt + 1)
                                {
                                    map[ny, nx] = temp.cnt + 1;
                                }
                            }
                        }

                        k++;
                    }

                }
            }
            else
            {
                int k = 1;
                while (true)
                {
                    ny = temp.y + dy[temp.direction] * k;
                    nx = temp.x + dx[temp.direction] * k;

                    if (ny < 0 || nx < 0 || ny >= n || nx >= n)
                        break;
                    if (map[ny, nx] == -1)
                        break;
                    if (mirrorDic.ContainsKey($"{ny} {nx}"))
                    {
                        if (visited[ny, nx] == 0)
                        {
                            pq.Push(ny, nx, temp.cnt, temp.direction);
                        }
                    }

                    if (map[ny, nx] == int.MaxValue)
                    {
                        map[ny, nx] = temp.cnt;
                    }
                    else
                    {
                        map[ny, nx] = Math.Min(map[ny, nx], temp.cnt);
                    }

                    k++;
                }
            }
        }
    }
}

class PosInfo
{
    public int y;
    public int x;

    public PosInfo(int _y, int _x)
    {
        this.y = _y;
        this.x = _x;
    }
}
class MirrorInfo
{
    public int y;
    public int x;
    public int cnt;
    public int direction;

    public MirrorInfo(int _y, int _x, int _cnt, int _dir)
    {
        this.y = _y;
        this.x = _x;
        this.cnt = _cnt;
        this.direction = _dir;
    }
}

class MinHeap
{
    public List<MirrorInfo> container;
    public int count;

    public MinHeap()
    {
        this.container = new List<MirrorInfo>();
        this.count = 0;
    }

    public void Push(int _y, int _x, int _cnt, int _dir)
    {
        this.container.Add(new MirrorInfo(_y, _x, _cnt, _dir));
        count++;
        HeapifyUp(count - 1);
    }

    public MirrorInfo Peek()
    {
        return container[0];
    }

    public void Pop()
    {
        Swap(0, count - 1);
        container.RemoveAt(count - 1);
        count--;
        HeapifyDown(0);
    }

    public void Swap(int _index1, int _index2)
    {
        MirrorInfo temp = container[_index1];
        container[_index1] = container[_index2];
        container[_index2] = temp;
    }

    public void HeapifyUp(int _index)
    {
        int parentIndex = 0;

        while (_index > 0)
        {
            parentIndex = (_index - 1) / 2;

            if (container[parentIndex].cnt > container[_index].cnt)
            {
                Swap(_index, parentIndex);
                _index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    public void HeapifyDown(int _index)
    {
        int leftChildIndex = 0;
        int rightChildIndex = 0;
        int minIndex = -1;

        while (true)
        {
            leftChildIndex = 2 * _index + 1;
            rightChildIndex = 2 * _index + 2;
            minIndex = _index;

            if (leftChildIndex < count && container[leftChildIndex].cnt < container[minIndex].cnt)
            {
                minIndex = leftChildIndex;
            }

            if (rightChildIndex < count && container[rightChildIndex].cnt < container[minIndex].cnt)
            {
                minIndex = rightChildIndex;
            }

            if (minIndex == _index)
            {
                break;
            }
            else
            {
                Swap(minIndex, _index);
                _index = minIndex;
            }
        }
    }
}