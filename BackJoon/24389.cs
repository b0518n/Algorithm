StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

uint n = uint.Parse(sr.ReadLine());
uint inverseValue = ~n + 1;
uint result = ~(inverseValue ^ n);

int cnt = 0;

for (int i = 0; i < 32; i++)
{
    if ((result & (1 << i)) == 0)
    {
        cnt++;
    }
}

sw.WriteLine(cnt);
sw.Flush();
sw.Close();