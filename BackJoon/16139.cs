// 모듈러 연산
// [i,j] 구간의 합 = sum[j] - sum[i - 1]
// (sum[j] - sum[i - 1]) % m == 0인 순서쌍의 개수.
// sum[j] % m - sum[i - 1] % m = 0
// sum[j] % m = sum[i - 1] % m

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

int[] sum = new int[n + 1];
for (int i = 1; i < n + 1; i++)
{
    sum[i] = (sum[i - 1] + input[i - 1]) % m;
}

long[] counts = new long[m];
for (int i = 1; i < n + 1; i++)
{
    counts[sum[i]] += 1;
}

long result = counts;
for (int i = 0; i < m; i++)
{
    result += counts[i];
    result += counts[i] * (counts[i] - 1) / 2;
}

sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();