int[] arr = new int[10000];
int value;

for (int i = 1; i < 10000; i++)
{
    if (i < 10)
    {
        value = i + 0 + (i % 10);
        arr[value - 1] = 1;
    }
    else if (i >= 10 && i < 100)
    {
        value = i + (i / 10) + (i % 10);
        arr[value - 1] = 1;
    }
    else if (i >= 100 && i < 1000)
    {
        //
        value = i + (i / 100) + ((i - ((i / 100) * 100)) / 10) + (i % 10);
        if (value >= 10000)
        {
            continue;
        }
        else
        {
            arr[value - 1] = 1;
        }
    }
    else if (i >= 1000 && i < 10000)
    {
        //
        value = i + (i / 1000) + ((i - ((i / 1000) * 1000)) / 100) + ((i - ((i / 100) * 100)) / 10) + (i % 10);
        if (value >= 10000)
        {
            continue;
        }
        else
        {
            arr[value - 1] = 1;
        }
    }
}

for (int i = 0; i < 9999; i++)
{
    if (arr[i] != 1)
    {
        Console.WriteLine(i + 1);
    }
}
