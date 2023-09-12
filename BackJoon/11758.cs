int[] input = null;

List<int[]> vertexs = new List<int[]>();

for (int i = 0; i < 3; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    vertexs.Add(new int[2] { input[0], input[1] });
}

vertexs.Add(new int[2] { vertexs[0][0], vertexs[0][1] });

int cost1 = 0;
int cost2 = 0;

int x = vertexs[0][0];
int y = vertexs[0][1];

for (int i = 1; i < vertexs.Count; i++)
{
    x *= vertexs[i][1];
    y *= vertexs[i][0];

    cost1 += x;
    cost2 += y;

    x = vertexs[i][0];
    y = vertexs[i][1];
}

int value = cost2 - cost1;
if (value < 0)
{
    Console.WriteLine(1);
}
else if (value == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(-1);
}