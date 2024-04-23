using System.Text;

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = null;
int x = 0;
int y = 0;

string bX = string.Empty;
string bY = string.Empty;
bool isFirst = true;

while (true)
{
    Input();
    if (x == 0 && y == 0)
    {
        break;
    }

    if (!isFirst)
    {
        sw.WriteLine();
    }
    else
    {
        isFirst = false;
    }

    GetBinaryNumber();
}

sw.Flush();
sw.Close();

void Input()
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    x = input[0];
    y = input[1];
}
void GetBinaryNumber()
{
    StringBuilder stringBuilder = new StringBuilder();
    for (int i = 7; i >= 0; i--)
    {
        if ((x & 1 << i) == 0)
        {
            stringBuilder.Append(0);
        }
        else
        {
            stringBuilder.Append(1);
        }
    }

    sw.WriteLine($"{x} = {stringBuilder}");
    stringBuilder.Clear();

    for (int i = 7; i >= 0; i--)
    {
        if ((y & 1 << i) == 0)
        {
            stringBuilder.Append(0);
        }
        else
        {
            stringBuilder.Append(1);
        }
    }

    sw.WriteLine($"{y} = {stringBuilder}");
    stringBuilder.Clear();

    int tValue = (~x + 1);
    for (int i = 7; i >= 0; i--)
    {
        if ((tValue & 1 << i) == 0)
        {
            stringBuilder.Append(0);
        }
        else
        {
            stringBuilder.Append(1);
        }
    }

    sw.WriteLine($"{-1 * x} = {stringBuilder}");
    stringBuilder.Clear();

    tValue = (~y + 1);
    for (int i = 7; i >= 0; i--)
    {
        if ((tValue & 1 << i) == 0)
        {
            stringBuilder.Append(0);
        }
        else
        {
            stringBuilder.Append(1);
        }
    }

    sw.WriteLine($"{-1 * y} = {stringBuilder}");
    stringBuilder.Clear();

    tValue = x - y;
    for (int i = 7; i >= 0; i--)
    {
        if ((tValue & 1 << i) == 0)
        {
            stringBuilder.Append(0);
        }
        else
        {
            stringBuilder.Append(1);
        }
    }

    sw.WriteLine($"{tValue} = {stringBuilder}");
    stringBuilder.Clear();

}