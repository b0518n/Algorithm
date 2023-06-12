StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int[] sum = new int[arr.Length + 1];
for (int i = 0; i < arr.Length; i++)
{
    sum[i + 1] = sum[i] + arr[i];
}

int start = 0;
int end = 0;

for (int i = 0; i < m; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    start = input[0];
    end = input[1];

    sw.WriteLine(sum[end] - sum[start - 1]);
}

sw.Close();