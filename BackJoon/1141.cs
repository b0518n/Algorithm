StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(sr.ReadLine());
string str = string.Empty;
Dictionary<int, List<string>> inputDataDic = new Dictionary<int, List<string>>();
int max = 0;
List<string> result = new List<string>();

for (int i = 0; i < n; i++)
{
    str = sr.ReadLine();
    if (inputDataDic.ContainsKey(str.Length))
    {
        inputDataDic[str.Length].Add(str);
    }
    else
    {
        inputDataDic.Add(str.Length, new List<string>());
        inputDataDic[str.Length].Add(str);
    }

    if (max == 0)
    {
        max = str.Length;
    }
    else
    {
        max = Math.Max(max, str.Length);
    }
}

for (int i = max; i > 0; i--)
{
    if (!inputDataDic.ContainsKey(i))
    {
        continue;
    }

    for (int j = 0; j < inputDataDic[i].Count; j++)
    {
        if (result.Count == 0)
        {
            result.Add(inputDataDic[i][j]);
        }
        else
        {
            bool isContain = false;
            for (int k = 0; k < result.Count; k++)
            {
                if (result[k].Length < inputDataDic[i][j].Length)
                {
                    continue;
                }
                else
                {
                    if (result[k].Substring(0, inputDataDic[i][j].Length) == inputDataDic[i][j])
                    {
                        isContain = true;
                        break;
                    }
                }

                if (k == result.Count - 1)
                {
                    result.Add(inputDataDic[i][j]);
                }
            }
        }
    }
}

sw.WriteLine(result.Count);
sw.Flush();
sw.Close();