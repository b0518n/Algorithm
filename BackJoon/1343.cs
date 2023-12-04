string str = Console.ReadLine();
int count = 0;
int mok = 0;
int nmg = 0;
string result = string.Empty;
bool doCover = true;

for (int i = 0; i < str.Length; i++)
{
    if (str[i].ToString() == "X")
    {
        count++;
    }
    else
    {
        Solve(1);
    }
}

Solve(0);
if (!doCover)
{
    result = "-1";
}

Console.WriteLine(result);

void Solve(int _case)
{
    if (count == 0)
    {
        if (_case == 1)
        {
            result += ".";
        }
        return;

    }
    else if (count < 2 || count == 3 || count % 2 != 0)
    {
        doCover = false;
    }
    else
    {
        mok = count / 4;
        nmg = count % 4;

        for (int j = 0; j < mok; j++)
        {
            result += "AAAA";
        }

        if (nmg != 0)
        {
            mok = nmg / 2;

            for (int j = 0; j < mok; j++)
            {
                result += "BB";
            }
        }
    }

    if (_case == 1)
    {
        result += ".";
    }
    count = 0;
}