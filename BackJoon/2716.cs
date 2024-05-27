StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
string input = null;

int leftSquareCnt = 0;
int max = 0;

for (int i = 0; i < n; i++)
{
    max = 0;
    input = sr.ReadLine();
    if (input == string.Empty)
    {
        max = 0;
    }
    else
    {
        for (int j = 0; j < input.Length; j++)
        {
            if (input[j].ToString() == "[")
            {
                leftSquareCnt++;
            }
            else if (input[j].ToString() == "]")
            {
                leftSquareCnt--;
            }

            max = Math.Max(max, leftSquareCnt);

        }
    }

    sw.WriteLine(Pow(max));
}

sw.Flush();
sw.Close();

ulong Pow(int value)
{
    ulong retValue = 1;

    for (int i = 0; i < value; i++)
    {
        retValue *= 2;
    }

    return retValue;
}