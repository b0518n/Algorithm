StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int a = 0; // 1시간 일할 경우 피로도
int b = 0; // 1시간 일할 경우 업무량
int c = 0; // 1시간 쉴 경우 줄어드는 피로도
int m = 0; // 번아웃 피로도

int result = 0;

Input();
Solve();
Print();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    a = input[0];
    b = input[1];
    c = input[2];
    m = input[3];
}
void Solve()
{
    int fatigue = 0;
    int time = 0;
    int value = 0;

    while (time < 24)
    {
        if (a > m)
        {
            break;
        }

        if (fatigue + a > m)
        {
            time++;
            fatigue -= c;
        }
        else
        {
            time++;
            fatigue += a;
            value += b;
        }

        if (fatigue < 0)
        {
            fatigue = 0;
        }
    }

    result = value;
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}