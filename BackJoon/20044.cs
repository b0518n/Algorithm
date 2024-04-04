StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
int[] scores = null;
int result = 0;

Input();
Array.Sort(scores);
MakeTeam();
Print();

void Input()
{
    n = int.Parse(sr.ReadLine());
    scores = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
}
void MakeTeam()
{
    int firstIndex = 0;
    int secondIndex = 2 * n - 1;

    int min = 0;

    while (true)
    {
        if (firstIndex > secondIndex)
        {
            break;
        }

        if (min == 0)
        {
            min = scores[firstIndex] + scores[secondIndex];
        }
        else
        {
            min = Math.Min(min, scores[firstIndex] + scores[secondIndex]);
        }

        firstIndex++;
        secondIndex--;
    }

    result = min;
    return;
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}