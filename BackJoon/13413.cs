StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
int n = 0;

string str1 = string.Empty;
string str2 = string.Empty;

int diffIndexCnt = 0;
int str1Wcnt = 0;
int str2Wcnt = 0;
int result = 0;

for (int i = 0; i < t; i++)
{
    n = int.Parse(sr.ReadLine());
    str1 = sr.ReadLine();
    str2 = sr.ReadLine();

    for (int j = 0; j < n; j++)
    {
        if (str1[j].ToString() != str2[j].ToString())
        {
            diffIndexCnt++;
        }

        if (str1[j].ToString() == "W")
            str1Wcnt++;
        if (str2[j].ToString() == "W")
            str2Wcnt++;
    }

    if (str1Wcnt == str2Wcnt)
    {
        result = diffIndexCnt / 2;
    }
    else
    {
        result += Math.Abs(str1Wcnt - str2Wcnt);
        diffIndexCnt -= Math.Abs(str1Wcnt - str2Wcnt);
        result += diffIndexCnt / 2;
    }

    sw.WriteLine(result);

    diffIndexCnt = 0;
    str1Wcnt = 0;
    str2Wcnt = 0;
    result = 0;
}

sw.Flush();
sw.Close();