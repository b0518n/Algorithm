StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
string k = sr.ReadLine();

int result = 0;
Calculate();
Print();

// ~k + 1 : k의 보수, k - (k & (~k + 1)) : 1인 비트 중 최하위 비트를 0으로 바꾼다
void Calculate()
{
    for (int i = k.Length - 1; i >= 0; i--)
    {
        if (k[i].ToString() == "1")
        {
            result++;
        }
    }
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}