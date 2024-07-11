StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
LineInfo line = new LineInfo();

for (int i = n - 1; i >= 0; i--)
{
    if (i == n - 1)
    {
        line.Add(i + 1);
    }
    else
    {
        line.AddAt(input[i], i + 1);
    }
}

sw.WriteLine(string.Join(" ", line.list));
sw.Flush();
sw.Close();

class LineInfo
{
    public List<int> list;
    public int count;

    public LineInfo()
    {
        list = new List<int>();
        count = 0;
    }

    public void Add(int _value)
    {
        list.Add(_value);
        count++;
    }

    public void AddAt(int _index, int _value)
    {
        list.Add(_value);
        count++;

        int _start = count - 1;

        while (true)
        {
            if (_start == _index)
                break;

            Swap(_start, _start - 1);
            _start--;
        }
    }

    public void Swap(int _index1, int _index2)
    {
        int temp = list[_index1];
        list[_index1] = list[_index2];
        list[_index2] = temp;
    }
}