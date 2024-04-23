StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int time = int.Parse(sr.ReadLine());

int hour = time / 100;
int minute = time - (hour * 100);

int h0 = 0;
int h1 = 0;
int m0 = 0;
int m1 = 0;

if (hour < 10)
{
    h0 = 0;
    h1 = hour;
}
else
{
    h0 = hour / 10;
    h1 = hour % 10;
}

if (minute < 10)
{
    m0 = 0;
    m1 = minute;
}
else
{
    m0 = minute / 10;
    m1 = minute % 10;
}

for (int i = 3; i >= 0; i--)
{
    if ((h0 & 1 << i) == 0)
    {
        sw.Write(". ");
    }
    else
    {
        sw.Write("* ");
    }

    if ((h1 & 1 << i) == 0)
    {
        sw.Write(".   ");
    }
    else
    {
        sw.Write("*   ");
    }

    if ((m0 & 1 << i) == 0)
    {
        sw.Write(". ");
    }
    else
    {
        sw.Write("* ");
    }

    if ((m1 & 1 << i) == 0)
    {
        sw.WriteLine(".");
    }
    else
    {
        sw.WriteLine("*");
    }
}

sw.Flush();
sw.Close();