StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int[,] arr = new int[9, 9];
int[] input = null;
List<int[]> list = new List<int[]>();
for (int i = 0; i < 9; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    for (int j = 0; j < 9; j++)
    {
        arr[i, j] = input[j];
        if (arr[i, j] == 0)
        {
            list.Add(new int[2] { i, j });
        }
    }
}

Sudoqu(0);

void Sudoqu(int index)
{
    if (index >= list.Count)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (j == 0)
                {
                    sw.Write(arr[i, j]);
                }
                else
                {
                    sw.Write(" " + arr[i, j]);
                }

                if (j == 8)
                {
                    sw.WriteLine();
                }
            }
        }

        sw.Close();
        Environment.Exit(0);
    }

    for (int i = 1; i <= 9; i++)
    {
        if (CheckPosition(list[index][0], list[index][1], i))
        {
            arr[list[index][0], list[index][1]] = i;
            Sudoqu(index + 1);
            arr[list[index][0], list[index][1]] = 0;
        }
    }

}

bool CheckPosition(int x, int y, int value)
{
    if (CheckPosition_Row(x, y, value) == false)
    {
        return false;
    }

    if (CheckPosition_Column(x, y, value) == false)
    {
        return false;
    }

    if (CheckPosition_Box(x, y, value) == false)
    {
        return false;
    }



    return true;
}

bool CheckPosition_Row(int x, int y, int value)
{
    for (int i = 1; i < 9; i++)
    {
        if (Check(x + i, y, value) == false)
        {
            return false;
        }

        if (Check(x - i, y, value) == false)
        {
            return false;
        }
    }

    return true;
}

bool CheckPosition_Column(int x, int y, int value)
{
    for (int i = 1; i < 9; i++)
    {
        if (Check(x, y + i, value) == false)
        {
            return false;
        }

        if (Check(x, y - i, value) == false)
        {
            return false;
        }
    }

    return true;
}

bool CheckPosition_Box(int x, int y, int value)
{
    if (x < 0 || x > 8 || y < 0 || y > 8)
    {
        return true;
    }

    if (Check_Box(x, y, value) == true)
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool Check(int x, int y, int value)
{
    if (x < 0 || x > 8 || y < 0 || y > 8)
    {
        return true;
    }

    if (arr[x, y] == value)
    {
        return false;
    }
    else
    {
        return true;
    }
}


bool Check_Box(int x, int y, int value)
{
    int startX = 0;
    int endX = 0;
    int startY = 0;
    int endY = 0;

    if (x <= 2)
    {
        startX = 0;
        endX = 2;
    }
    else if (x >= 3 && x <= 5)
    {
        startX = 3;
        endX = 5;
    }
    else if (x >= 6 && x <= 8)
    {
        startX = 6;
        endX = 8;
    }

    if (y <= 2)
    {
        startY = 0;
        endY = 2;
    }
    else if (y >= 3 && y <= 5)
    {
        startY = 3;
        endY = 5;
    }
    else if (y >= 6 && y <= 8)
    {
        startY = 6;
        endY = 8;
    }

    for (int i = startX; i <= endX; i++)
    {
        for (int j = startY; j <= endY; j++)
        {
            if (i == x && j == y)
            {
                continue;
            }

            if (arr[i, j] == value)
            {
                return false;
            }
        }
    }


    return true;
}