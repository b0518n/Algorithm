int n = int.Parse(Console.ReadLine());
int[] input = null;
StringBuilder sb = new StringBuilder();

for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    sb.AppendLine(GetUniversity(CompareWidth(input[0], input[1], input[2], input[3])).ToString());
}

Console.WriteLine(sb.ToString());

int CompareWidth(int l1, int w1, int l2, int w2)
{
    BigInteger width1 = (BigInteger)l1 * w1;
    BigInteger width2 = (BigInteger)l2 * w2;

    if (width1 > width2)
    {
        return 1;
    }
    else if (width1 < width2)
    {
        return 2;
    }
    else
    {
        return 0;
    }
}

string GetUniversity(int n)
{
    string result = string.Empty;

    if (n == 1)
    {
        result = "TelecomParisTech";
    }
    else if (n == 2)
    {
        result = "Eurecom";
    }
    else
    {
        result = "Tie";
    }

    return result;
}