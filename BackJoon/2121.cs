StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];

Dictionary<string, int> dots = new Dictionary<string, int>();
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
    dots.Add($"{input[0]} {input[1]}", 0);
}

int result = 0;

string[] temp = null;
int y = 0;
int x = 0;
foreach (string key in dots.Keys)
{
    temp = key.Split();
    y = int.Parse(temp[0]);
    x = int.Parse(temp[1]);

    if (!dots.ContainsKey($"{y + a} {x + b}"))
    {
        continue;
    }

    if (!dots.ContainsKey($"{y + a} {x}"))
    {
        continue;
    }

    if (!dots.ContainsKey($"{y} {x + b}"))
    {
        continue;
    }

    result++;
}

sw.WriteLine(result);
sw.Flush();
sw.Close();