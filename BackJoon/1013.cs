int t = int.Parse(Console.ReadLine());
string input = null;
StringBuilder sb = new StringBuilder();
bool result = false;
for (int i = 0; i < t; i++)
{
    input = Console.ReadLine();
    result = CheckPattern(input);
    if (result)
    {
        sb.AppendLine("YES");
    }
    else
    {
        sb.AppendLine("NO");
    }
}

Console.WriteLine(sb.ToString());


bool CheckPattern(string str)
{
    string[] regexs = new string[2] { @"^(01)+", @"^(100+1+)+" };
    string _str = str.Substring(0, str.Length);

    while (true)
    {
        if (_str.Length == 0)
        {
            break;
        }

        Regex regex = new Regex(regexs[0]);
        Match mc = regex.Match(_str);
        int index = mc.Index;
        string value = mc.Value;

        if (value != string.Empty && index == 0)
        {
            _str = _str.Substring(value.Length, _str.Length - value.Length);
            continue;
        }

        regex = new Regex(regexs[1]);
        mc = regex.Match(_str);
        index = mc.Index;
        value = mc.Value;

        if (_str.Length == value.Length)
        {
            _str = string.Empty;
            break;
        }
        else if (_str.Length < value.Length + 2)
        {
            break;
        }

        if (value != string.Empty && index == 0)
        {
            string temp = _str[value.Length].ToString() + _str[value.Length + 1].ToString();
            if (temp == "01")
            {
                _str = _str.Substring(value.Length + 2, _str.Length - (value.Length + 2));
                continue;
            }
            else if (temp == "00")
            {
                if (_str[value.Length - 2] == '1')
                {
                    _str = _str.Substring(value.Length - 1, _str.Length - (value.Length - 1));
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            break;
        }

    }

    if (_str.Length == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}