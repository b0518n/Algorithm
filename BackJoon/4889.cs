StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string str = string.Empty;
int sequence = 0;
int left = 0;
int cnt = 0;

while (true)
{
    str = sr.ReadLine();
    if (str[0].ToString() == "-")
    {
        break;
    }

    sequence++;
    left = 0;
    cnt = 0;

    for (int i = 0; i < str.Length; i++)
    {
        if (str[i].ToString() == "{")
        {
            left++;
        }
        else if (str[i].ToString() == "}")
        {
            if (left == 0)
            {
                cnt++;
                left++;
            }
            else
            {
                left--;
            }
        }
    }

    if (left > 0)
    {
        cnt += left / 2;
    }

    sw.WriteLine($"{sequence}. {cnt}");
}

sw.Flush();
sw.Close();