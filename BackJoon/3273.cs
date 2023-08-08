StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
Dictionary<int, int> dics = new Dictionary<int, int>();
for (int i = 0; i < arr.Length; i++)
{
    dics.Add(arr[i], 1);
}

int x = int.Parse(Console.ReadLine());
int count = 0;
int value = 0;

for (int i = 0; i < arr.Length; i++)
{
    value = x - arr[i];

    if (arr[i] == value)
    {
        continue;
    }

    if (dics.ContainsKey(value))
    {
        count++;
    }
}

sw.WriteLine(count / 2);
sw.Flush();
sw.Close();