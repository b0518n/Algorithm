StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int a = 0;
int b = 0;
int c = 0;
int result = 0;

Input();
PerformXOR();
Print();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];
}
void PerformXOR()
{
    int repeatCnt = c % 2 == 0 ? 2 : 1;

    for (int i = 0; i < repeatCnt; i++)
    {
        if (i == 0)
        {
            result = a ^ b;
        }
        else
        {
            result = result ^ b;
        }
    }
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}