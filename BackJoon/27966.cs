StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

long n = long.Parse(sr.ReadLine());

// 한 정점에 모든 정점을 연결하는 경우가 두 정점사이 거리의 합이 최소가 되는 경우
// 두 정점의 거리의 합은 1 * (n - 1) + 2 * (n - 2) + 2 * (n - 2) + ... + 2 * 1
// (n - 1) + (n - 1) * (n - 2)
// 식을 간략화 하면 (n - 1) * (n - 1)이 될 수 있음.
sw.WriteLine((n - 1) * (n - 1));
for (int i = 1; i < n; i++)
{
    sw.WriteLine($"1 {i + 1}");
}

sw.Flush();
sw.Close();