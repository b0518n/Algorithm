string str1 = Console.ReadLine();
string str2 = Console.ReadLine();

int m = str1.Length;
int n = str2.Length;

int[,] arr = new int[n + 1, m + 1];

for (int i = 1; i < n + 1; i++)
{
    for (int j = 1; j < m + 1; j++)
    {
        if (str1[j - 1] == str2[i - 1])
        {
            arr[i, j] = arr[i - 1, j - 1] + 1;
        }
        else
        {
            arr[i, j] = Math.Max(arr[i - 1, j], arr[i, j - 1]);
        }
    }
}

Console.WriteLine(arr[n, m]);