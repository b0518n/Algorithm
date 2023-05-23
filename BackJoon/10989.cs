var sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] arr = new int[10001];
int value = 0;
for (int i = 0; i < n; i++)
{
    value = int.Parse(Console.ReadLine());
    arr[value]++;
}

for (int i = 0; i < arr.Length; i++)
{
    while (arr[i] != 0)
    {
        sw.WriteLine(i.ToString());
        arr[i]--;
    }
}

sw.Close();