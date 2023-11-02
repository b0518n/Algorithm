int n = int.Parse(Console.ReadLine());
int input = 0;
List<int> sequenceA = new List<int>();
List<int> sequenceB = new List<int>();
List<int> sequenceC = new List<int>();

for (int i = 0; i < n; i++)
{
    input = int.Parse(Console.ReadLine());
    if (input <= 0)
    {
        sequenceA.Add(input);
    }
    else if (input == 1)
    {
        sequenceC.Add(input);
    }
    else
    {
        sequenceB.Add(input);
    }
}

sequenceA.Sort();
sequenceB.Sort();

int result = 0;

for (int i = 0; i < sequenceA.Count; i += 2)
{
    if (i <= sequenceA.Count - 2)
    {
        result += sequenceA[i] * sequenceA[i + 1];
    }
    else
    {
        result += sequenceA[i];
    }
}

for (int i = sequenceB.Count - 1; i >= 0; i -= 2)
{
    if (i >= 1)
    {
        result += sequenceB[i] * sequenceB[i - 1];
    }
    else
    {
        result += sequenceB[i];
    }
}

for (int i = 0; i < sequenceC.Count; i++)
{
    result += sequenceC[i];
}

Console.WriteLine(result);