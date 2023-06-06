StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int t = int.Parse(Console.ReadLine());
int input = 0;
long[] arr = new long[101];
arr[1] = 1;
arr[2] = 1;
arr[3] = 1;
arr[4] = 2;
arr[5] = 2;
for (int i = 6; i <= 100; i++)
{
    arr[i] = arr[i - 5] + arr[i - 1];
}

for (int i = 0; i < t; i++)
{
    input = int.Parse(Console.ReadLine());
    sw.WriteLine(arr[input]);
}

sw.Close();