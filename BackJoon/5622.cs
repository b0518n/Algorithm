string str = Console.ReadLine();
int result = 0;
for (int i = 0; i < str.Length; i++)
{
    result += CalculateCost(str[i]);
}

Console.WriteLine(result);

int CalculateCost(char c)
{
    if (c == 'A' || c == 'B' || c == 'C')
    {
        return 3;
    }
    else if (c == 'D' || c == 'E' || c == 'F')
    {
        return 4;
    }
    else if (c == 'G' || c == 'H' || c == 'I')
    {
        return 5;
    }
    else if (c == 'J' || c == 'K' || c == 'L')
    {
        return 6;
    }
    else if (c == 'M' || c == 'N' || c == 'O')
    {
        return 7;
    }
    else if (c == 'P' || c == 'Q' || c == 'R' || c == 'S')
    {
        return 8;
    }
    else if (c == 'T' || c == 'U' || c == 'V')
    {
        return 9;
    }
    else
    {
        return 10;
    }
}