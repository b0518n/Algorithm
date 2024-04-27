StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int m = input[0];
int b = input[1];
int s = input[2];

string str = string.Empty;
int[] arr = new int[s];

for (int i = 0; i < b; i++)
{
    str = sr.ReadLine();
    if (str[m - 1] == '0')
    {
        continue;
    }

    for (int j = 0; j < s; j++)
    {
        arr[j] = arr[j] | int.Parse(str[j].ToString());
    }
}

int result = 0;

for (int i = 0; i < s; i++)
{
    if (i == m - 1)
    {
        continue;
    }
    else
    {
        if (arr[i] == 1)
        {
            result++;
        }
    }
}

sw.WriteLine(result);
sw.Flush();
sw.Close();