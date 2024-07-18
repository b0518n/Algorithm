StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

string[] input = sr.ReadLine().Split();
string str1 = input[0];
string str2 = input[1];

int _result = -1;
int _tempResult = 0;

if (str1.Length == str2.Length)
{
    for (int i = 0; i < str1.Length; i++)
    {
        if (str1[i] != str2[i])
        {
            _tempResult++;
        }
    }

    _result = _tempResult;
}
else
{
    for (int i = 0; i <= str2.Length - str1.Length; i++)
    {
        _tempResult = 0;

        for (int j = 0; j < str1.Length; j++)
        {
            if (str1[j] != str2[j + i])
            {
                _tempResult++;
            }
        }

        if (_result == -1)
        {
            _result = _tempResult;
        }
        else
        {
            _result = Math.Min(_result, _tempResult);
        }
    }
}

sw.WriteLine(_result);
sw.Flush();
sw.Close();