StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
int[] input = null;
int[,] matrix = null;
int[] sequence = null;

Input();
FindSequence();
Print();


void Input()
{
    n = int.Parse(sr.ReadLine());
    matrix = new int[n, n];
    sequence = new int[n];

    for (int i = 0; i < n; i++)
    {
        input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        for (int j = 0; j < n; j++)
        {
            matrix[i, j] = input[j];
        }
    }

}
void FindSequence()
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            sequence[i] |= matrix[i, j];
            sequence[j] |= matrix[i, j];
        }
    }
}
void Print()
{
    sw.WriteLine(string.Join(" ", sequence));
    sw.Flush();
    sw.Close();
}