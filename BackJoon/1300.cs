// n * n의 행렬을 하나의 배열로 정렬 시키면 n*n 크기의 배열이 만들어진다.
// 그 행렬을 A라고 하고, A[7] = 6 이면,
// 6보다 작거나 같은 원소는 배열에 7개 있다는 의미로 생각할 수 있다.
// 해당 문제는 x 보다 작거나 같은 원소의 개수가 k인 x를 찾는 문제라고 생각할 수 있다.

StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

long n = long.Parse(sr.ReadLine());
long k = long.Parse(sr.ReadLine());

long start = 1;
long end = n * n;
long mid = 0;
long count = 0;
long result = 0;

while (start <= end)
{
    mid = (start + end) / 2;
    count = 0;

    for (int i = 1; i <= n; i++)
    {
        count += Math.Min(mid / i, n);
    }

    if (count >= k)
    {
        end = mid - 1;
        result = mid;
    }
    else
    {
        start = mid + 1;
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();