StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
int[] input = null;
int n = 0;
int k = 0;

int[] arr = new int[6] { 1, 3, 7, 15, 31, 63 };
string result = string.Empty;

for (int i = 0; i < t; i++)
{
    Input();
    result = CheckOnOff();
    Print(i);
}

sw.Flush();
sw.Close();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    n = input[0];
    k = input[1];
}
string CheckOnOff()
{
    return n - 1 > 5 ? "OFF" : (arr[n - 1] & k) == arr[n - 1] ? "ON" : "OFF";
}
void Print(int index)
{
    sw.WriteLine($"Case #{index + 1}: {result}");
}