using System.Text;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string input = null;
string[] inputArr = null;
string s = string.Empty;
string t = string.Empty;
StringBuilder sb = new StringBuilder();
int index = 0;

while (true)
{
    index = 0;
    input = sr.ReadLine();

    if (input == null || input == "")
        break;

    inputArr = input.Split();
    s = inputArr[0];
    t = inputArr[1];

    for (int i = 0; i < t.Length; i++)
    {
        if (index > s.Length - 1)
            break;

        if (s[index] == t[i])
        {
            index++;
        }
    }

    if (index > s.Length - 1)
    {
        sb.AppendLine("Yes");
    }
    else
    {
        sb.AppendLine("No");
    }
}

sw.WriteLine(sb.ToString());
sw.Flush();
sw.Close();