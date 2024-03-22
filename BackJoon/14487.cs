StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
int[] input = null;

int max = -1;
int sum = 0;

Input();
GetMaxCostAndSum();
Print();

void Input()
{
    n = int.Parse(sr.ReadLine());
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
}
void GetMaxCostAndSum()
{
    for (int i = 0; i < n; i++)
    {
        max = Math.Max(max, input[i]);
        sum += input[i];
    }
}
void Print()
{
    sw.WriteLine(sum - max);
    sw.Flush();
    sw.Close();
}