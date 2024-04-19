StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
string str1 = null;
string str2 = null;
int distance = 0;

for (int i = 0; i < t; i++)
{
    Input();
    CalculateHammingDistance();
    Print();
}

sw.Flush();
sw.Close();

void Input()
{
    str1 = sr.ReadLine();
    str2 = sr.ReadLine();
}
void CalculateHammingDistance()
{
    int retValue = 0;

    for (int i = 0; i < str1.Length; i++)
    {
        if ((int.Parse(str1[i].ToString()) ^ int.Parse(str2[i].ToString())) == 1)
        {
            retValue++;
        }
    }

    distance = retValue;
}
void Print()
{
    sw.WriteLine($"Hamming distance is {distance}.");
}