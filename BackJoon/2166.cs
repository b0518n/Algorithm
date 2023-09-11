int n = int.Parse(Console.ReadLine());
int[] input = null;

List<int[]> vertexs = new List<int[]>();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    vertexs.Add(new int[2] { input[0], input[1] });
}

vertexs.Add(new int[2] { vertexs[0][0], vertexs[0][1] });

double cost1 = 0.0f;
double cost2 = 0.0f;

long x = vertexs[0][0];
long y = vertexs[0][1];

for (int i = 1; i < vertexs.Count; i++)
{
    x *= vertexs[i][1];
    y *= vertexs[i][0];

    cost1 += x;
    cost2 += y;

    x = vertexs[i][0];
    y = vertexs[i][1];
}

double value = Math.Abs(cost1 - cost2) / 2;
string result = value.ToString("0.0");

Console.WriteLine(result);