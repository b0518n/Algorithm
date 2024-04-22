StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int s = 0;
int m = 0;
string result = string.Empty;

Input();
PayforSandwich();
Print();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    s = input[0];
    m = input[1];
}
void PayforSandwich()
{
    int tValue;

    if (s <= 1023)
    {
        result = "No thanks";
    }
    else
    {
        tValue = s - 1023;
        if ((tValue & m) == 0)
        {
            result = "Impossible";
        }
        else
        {
            tValue = tValue - (tValue & m);
            if (tValue == 0)
            {
                result = "Thanks";
            }
            else
            {
                result = "Impossible";
            }
        }
    }
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}