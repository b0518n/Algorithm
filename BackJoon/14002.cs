StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
int n = int.Parse(Console.ReadLine());
int[] sequence = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] _sequence = new int[n];
List<int[]> list = new List<int[]>();
list.Add(new int[2] { 0, 0 });
for (int i = 0; i < n; i++)
{
    if (i == 0)
    {
        list.Add(new int[2] { 1, sequence[i] });
        _sequence[i] = 1;
    }
    else
    {
        for (int j = list.Count - 1; j >= 0; j--)
        {
            if (list[j][1] < sequence[i])
            {
                if (j == list.Count - 1)
                {
                    list.Add(new int[2] { list[list.Count - 1][0] + 1, sequence[i] });
                    _sequence[i] = list[list.Count - 1][0];
                }
                else
                {
                    list[j + 1][1] = sequence[i];
                    _sequence[i] = list[j + 1][0];
                }
                break;
            }

        }
    }
}

sw.WriteLine(list[list.Count - 1][0]);
int minIndex = 1;
int index = list[list.Count - 1][0];
int k = sequence.Length - 1;
List<int> result = new List<int>();

while (index >= minIndex)
{
    if (_sequence[k] == index)
    {
        result.Add(sequence[k]);
        k--;
        index--;
    }
    else
    {
        k--;
    }
}

for (int i = result.Count - 1; i >= 0; i--)
{
    if (i == result.Count - 1)
    {
        sw.Write(result[i]);
    }
    else
    {
        sw.Write(" " + result[i]);
    }
}

sw.Flush();
sw.Close();