StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

List<int> straws = new List<int>();
int n = int.Parse(sr.ReadLine());
for (int i = 0; i < n; i++)
{
    straws.Add(int.Parse(sr.ReadLine()));
}

straws.Sort((x, y) =>
{
    int compare = x.CompareTo(y) * -1;
    return compare;
});

int index = 0;
int a = 0;
int b = 0;
int c = 0;

int result = -1;

while (true)
{
    if (index + 2 > straws.Count - 1) break;

    a = straws[index];
    b = straws[index + 1];
    c = straws[index + 2];

    if (a < b + c)
    {
        result = a + b + c;
        break;
    }
    else
    {
        index++;
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();