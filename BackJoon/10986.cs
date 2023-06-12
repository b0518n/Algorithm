// [i,j] 구간의 합 = sum[j] - sum[i - 1]
// (sum[j] - sum[i - 1]) % m == 0인 순서쌍의 개수.
// sum[j] % m - sum[i - 1] % m = 0
// sum[j] % m = sum[i - 1] % m
// j >= i -> j > i - 1
// 예를 들어 j가 0이고 i가 0 일경우
// i - 1은 -1 즉 음수가 나와서 Index error 발생
// 이를 방지하기 위해 sum의 크기가 n이 아닌 n + 1로 설정

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
for (int i = 0; i < n + 1; i++)
{
    counts[sum[i]] += 1;
}

long result = 0;
for (int i = 0; i < m; i++)
{
    result += counts[i] * (counts[i] - 1) / 2;
}

sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();