int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
string str = string.Empty;
string[] arr = new string[n];
string[] arr1 = new string[m];

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    arr[i] = str;
}

for (int i = 0; i < m; i++)
{
    str = Console.ReadLine();
    arr1[i] = str;
}

int count = 0;
for (int i = 0; i < m; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (arr[j] == arr1[i])
        {
            count++;
        }
    }
}

Console.WriteLine(count);