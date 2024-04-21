StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int a = 0;
int b = 0;
int c = 0;

Input();
CalculateCScore();
Print();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
}
void CalculateCScore()
{
    c = a ^ b;
}
void Print()
{
    sw.WriteLine(c);
    sw.Flush();
    sw.Close();
}