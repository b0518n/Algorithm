StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int jimin = input[1];
int hansu = input[2];
int result = 0;

while (jimin != hansu)
{
    result++;
    jimin = (jimin + 1) / 2;
    hansu = (hansu + 1) / 2;
}

sw.Write(result);
sw.Flush();
sw.Close();