StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int q = input[1];

int[] nodeArr = new int[n + 1];
int blockNodeNum = -1;

InputData_Fun(q);
sw.Flush();
sw.Close();

void InputData_Fun(int _cnt)
{
    for (int i = 0; i < _cnt; i++)
    {
        if (CanGo_Fun(int.Parse(sr.ReadLine())))
        {
            sw.WriteLine(0);
        }
        else
        {
            sw.WriteLine(blockNodeNum);
        }
    }
}
bool CanGo_Fun(int _nodeNum)
{
    Stack<int> stack = new Stack<int>();
    stack.Push(_nodeNum);

    while (_nodeNum > 1)
    {
        _nodeNum /= 2;
        stack.Push(_nodeNum);
    }

    int temp = 0;

    while (stack.Count > 0)
    {
        temp = stack.Pop();
        if (nodeArr[temp] == 1)
        {
            blockNodeNum = temp;
            return false;
        }
    }

    nodeArr[temp] = 1;
    return true;
}