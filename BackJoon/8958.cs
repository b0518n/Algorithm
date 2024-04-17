int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int value = 0;
    int previousValue = 0;
    string str = Console.ReadLine();
    for (int j = 0; j < str.Length; j++)
    {
        if (j == 0)
        {
            if (str[j].ToString().Equals("O"))
            {
                value += 1;
                previousValue = 1;
            }
        }
        else
        {
            if (str[j].ToString().Equals("O"))
            {
                value += previousValue + 1;
                previousValue = previousValue + 1;
            }
            else
            {
                previousValue = 0;
            }
        }

    }
    Console.WriteLine(value);
}
