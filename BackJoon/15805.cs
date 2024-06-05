StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] routeArr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int[] parentNumArr = new int[n];
parentNumArr[routeArr[0]] = -1;

int parentNodeNum = routeArr[0];
int maxNodeNum = 0;

for (int i = 1; i < n; i++)
{
    if (parentNumArr[routeArr[i]] != 0)
    {
        parentNodeNum = routeArr[i];
    }
    else
    {
        if (parentNodeNum == 0)
        {
            parentNumArr[routeArr[i]] = int.MaxValue;
        }
        else
        {
            parentNumArr[routeArr[i]] = parentNodeNum;
        }

        parentNodeNum = routeArr[i];
        maxNodeNum = Math.Max(maxNodeNum, routeArr[i]);
    }
}

sw.WriteLine(maxNodeNum + 1);
for (int i = 0; i < maxNodeNum + 1; i++)
{
    if (i == maxNodeNum)
    {
        sw.Write(parentNumArr[i] == int.MaxValue ? 0 : parentNumArr[i]);
    }
    else
    {
        if (parentNumArr[i] == int.MaxValue)
            sw.Write(0 + " ");
        else
            sw.Write($"{parentNumArr[i]} ");
    }
}

sw.Flush();
sw.Close();