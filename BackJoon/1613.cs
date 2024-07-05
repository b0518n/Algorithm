StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];

int[,] incidentArr = new int[n + 1, n + 1];

InitIncident_Func();
Input_Func();

void InitIncident_Func()
{
    for (int i = 1; i < n + 1; i++)
    {
        for (int j = 1; j < n + 1; j++)
        {
            if (i == j)
                continue;

            incidentArr[i, j] = int.MaxValue;
        }
    }
}
void Input_Func()
{
    for (int i = 0; i < k; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        incidentArr[input[0], input[1]] = -1;
        incidentArr[input[1], input[0]] = 1;
    }

    Floyd_Warshall_Func();

    int s = int.Parse(sr.ReadLine());
    for (int i = 0; i < s; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        if (incidentArr[input[0], input[1]] == int.MaxValue)
        {
            sw.WriteLine(0);
        }
        else
        {
            sw.WriteLine(incidentArr[input[0], input[1]]);
        }
    }

    sw.Flush();
    sw.Close();
}
void Floyd_Warshall_Func()
{
    for (int i = 1; i < n + 1; i++) // 중간
    {
        for (int j = 1; j < n + 1; j++) // 시작
        {
            if (i == j)
                continue;
            if (incidentArr[j, i] == int.MaxValue)
                continue;

            for (int k = 1; k < n + 1; k++) // 끝
            {
                if (i == k)
                    continue;

                if (incidentArr[j, i] == incidentArr[i, k])
                {
                    incidentArr[j, k] = incidentArr[j, i];
                }
            }
        }
    }
}