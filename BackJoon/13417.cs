using System.Text;

StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(sr.ReadLine());
int n = 0;
char[] input = null;
StringBuilder sb = new StringBuilder();
char firstChar = 'a';

for (int i = 0; i < t; i++)
{
    n = int.Parse(sr.ReadLine());
    input = Array.ConvertAll(sr.ReadLine().Split(), char.Parse);
    for (int j = 0; j < n; j++)
    {
        if (j == 0)
        {
            sb.Append(input[j]);
            firstChar = input[j];
        }
        else
        {
            if (firstChar >= input[j])
            {
                sb.Insert(0, input[j]);
                firstChar = input[j];
            }
            else
            {
                sb.Append(input[j]);
            }
        }
    }

    sw.WriteLine(sb.ToString());
    sb.Clear();
}

sw.Flush();
sw.Close();