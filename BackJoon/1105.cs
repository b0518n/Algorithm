StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] input = sr.ReadLine().Split();
string l = input[0];
string r = input[1];

int result = 0;

if (l.Length != r.Length)
{
    result = 0;
}
else
{
    int index = 0;
    int cnt = 0;
    while (true)
    {
        if (index >= l.Length)
        {
            break;
        }

        if (l[index] == r[index])
        {
            if (l[index].ToString() == "8")
            {
                cnt++;
            }
            index++;
        }
        else
        {
            break;
        }
    }

    result = cnt;
}

sw.WriteLine(result);
sw.Flush();
sw.Close();