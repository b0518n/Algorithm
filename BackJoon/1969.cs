int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int n = input[0];
int m = input[1];
string[,] arr = new string[n, m];
string str = null;

for (int i = 0; i < n; i++)
{
    str = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        arr[i, j] = str[j].ToString();
    }
}

Dictionary<string, int> dics = null;
int max = 0;
string _str = string.Empty;
int hammingDistance = 0;
string dna = string.Empty;

for (int j = 0; j < m; j++)
{
    dics = new Dictionary<string, int>();
    max = 0;
    _str = string.Empty;

    for (int i = 0; i < n; i++)
    {
        if (dics.ContainsKey(arr[i, j]))
        {
            dics[arr[i, j]]++;
            if (max < dics[arr[i, j]])
            {
                max = dics[arr[i, j]];
                _str = arr[i, j];
            }
            else if (max == dics[arr[i, j]])
            {
                if ((int)_str[0] > (int)arr[i, j][0])
                {
                    max = dics[arr[i, j]];
                    _str = arr[i, j];
                }
            }
        }
        else
        {
            dics.Add(arr[i, j], 1);
            if (max == 0)
            {
                max = 1;
                _str = arr[i, j];
            }
            else if (max == 1)
            {
                if ((int)_str[0] > (int)arr[i, j][0])
                {
                    _str = arr[i, j];
                }
            }
        }
    }

    foreach (string key in dics.Keys)
    {
        if (key == _str)
        {
            dna += key;
            continue;
        }
        else
        {
            hammingDistance += dics[key];
        }
    }

}

Console.WriteLine(dna);
Console.WriteLine(hammingDistance);