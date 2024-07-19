StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];

int size = Math.Min(n, m);

string str = string.Empty;
string[] arr = new string[n];
int result = 1;

for (int i = 0; i < n; i++)
{
    arr[i] = sr.ReadLine();
}

for (int i = size; i >= 2; i--)
{
    if (SearchSquare(i) == true)
        break;
}

sw.WriteLine(result);
sw.Flush();
sw.Close();

bool SearchSquare(int _size)
{
    bool isContain = false;

    for (int i = 0; i < n - _size + 1; i++)
    {
        if (isContain)
            break;

        for (int j = 0; j < m - _size + 1; j++)
        {
            if (arr[i][j].ToString() == arr[i][j + _size - 1].ToString() && arr[i][j].ToString() == arr[i + _size - 1][j].ToString() && arr[i][j + _size - 1].ToString() == arr[i + _size - 1][j + _size - 1].ToString())
            {
                isContain = true;
                result = _size * _size;
                break;
            }
        }
    }

    return isContain;
}