StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
List<List<int>> edgeList = new List<List<int>>();

Activate_EdgeList_Func(n);
InputData_Fun(n);

int q = int.Parse(sr.ReadLine());
InputAndSolveProblem_Fun(q);
sw.Flush();
sw.Close();

void Activate_EdgeList_Func(int _vertexCnt)
{
    for (int i = 0; i < _vertexCnt + 1; i++)
    {
        edgeList.Add(new List<int>());
    }
}
void InputData_Fun(int _edgeCnt)
{
    int[] input = null;
    int a = 0;
    int b = 0;
    int edgeSequence = 1;

    for (int i = 1; i < _edgeCnt; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        a = input[0];
        b = input[1];

        edgeList[a].Add(b);
        edgeList[b].Add(a);

        edgeSequence++;
    }
}
void InputAndSolveProblem_Fun(int _problemCnt)
{
    int[] input = null;
    int t = 0;
    int k = 0;

    for (int i = 0; i < _problemCnt; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        t = input[0];
        k = input[1];

        SolveProblem_Func(n, t, k);
    }
}
void SolveProblem_Func(int _vertexCnt, int _t, int _k)
{
    if (_t == 1)
    {
        for (int i = 1; i < _vertexCnt + 1; i++)
        {
            if (i != _k)
            {
                bool isCutVertex = CheckCutVertex_Func(_k);
                sw.WriteLine(isCutVertex == true ? "yes" : "no");
                break;
            }
        }
    }
    else if (_t == 2)
    {
        sw.WriteLine("yes");
    }

    return;
}
bool CheckCutVertex_Func(int _disconnectedVertex)
{
    bool isCutVertex = edgeList[_disconnectedVertex].Count >= 2 ? true : false;
    return isCutVertex;
}