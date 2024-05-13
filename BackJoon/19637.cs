StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
string[] input = sr.ReadLine().Split();
int n = int.Parse(input[0]);
int m = int.Parse(input[1]);

string[] titleNames = new string[n];
int[] titleValues = new int[n];

for (int i = 0; i < n; i++)
{
    input = sr.ReadLine().Split();
    titleNames[i] = input[0];
    titleValues[i] = int.Parse(input[1]);
}

for (int i = 0; i < m; i++)
{
    BinarySearch(int.Parse(sr.ReadLine()));
}

sw.Flush();
sw.Close();

void BinarySearch(int value)
{
    int left = 0;
    int right = n - 1;
    int middle = 0;

    while (left <= right)
    {
        middle = (left + right) / 2;
        if (value > titleValues[middle])
        {
            left = middle + 1;
        }
        else
        {
            right = middle - 1;
        }
    }

    sw.WriteLine(titleNames[left]);
}