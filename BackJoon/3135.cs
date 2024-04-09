StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int a = 0;
int b = 0;
int n = 0;
List<int> frequnecys = new List<int>();
int result = 0;

Input();
GetButtonCount();
Print();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    n = int.Parse(sr.ReadLine());

    for (int i = 0; i < n; i++)
    {
        frequnecys.Add(int.Parse(sr.ReadLine()));
    }
}
void GetButtonCount()
{
    int minDiff = -1;
    int cnt = 0;

    for (int i = 0; i < n; i++)
    {
        if (minDiff == -1)
        {
            minDiff = Math.Abs(b - frequnecys[i]);
        }
        else
        {
            minDiff = Math.Min(minDiff, Math.Abs(b - frequnecys[i]));
        }
    }

    if (Math.Abs(b - a) > minDiff)
    {
        cnt = 1 + minDiff;
    }
    else
    {
        cnt = Math.Abs(b - a);
    }

    result = cnt;
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}