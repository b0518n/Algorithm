// 페르마의 소정리
StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int k = input[1];
int p = 1000000007;

long[] arr = new long[n + 1];
arr[0] = 1;
arr[1] = 1;

for (int i = 2; i < arr.Length; i++)
{
    arr[i] = arr[i - 1] * i % p;
}

long result = arr[n] % p * Pow(arr[k] % p * arr[n - k] % p, p - 2) % p;
sw.WriteLine(result);
sw.Flush();
sw.Close();
sr.Close();

long Pow(long n, long r)
{
    if (r == 1)
    {
        return n % p;
    }

    long tmp = Pow(n, r / 2);

    if (r % 2 == 1)
    {
        return (tmp % p * tmp % p) * n % p;
    }
    else
    {
        return tmp % p * tmp % p;
    }
}