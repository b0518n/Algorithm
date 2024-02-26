StreamWriter sw = new(new BufferedStream(Console.OpenStandardOutput()));

int x;
int y;
int z;

int _value;
int __value;
int max;

while (true)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
    x = input[0];
    y = input[1];
    z = input[2];

    if (x == 0 && y == 0 && z == 0)
    {
        break;
    }
    else
    {
        if (x >= y)
        {
            if (x >= z)
            {
                max = x;
                _value = z;
                __value = y;
            }
            else
            {
                max = z;
                _value = x;
                __value = y;
            }
        }
        else
        {
            if (y >= z)
            {
                max = y;
                _value = x;
                __value = z;
            }
            else
            {
                max = z;
                _value = x;
                __value = y;
            }
        }

        if ((max * max) == (_value * _value) + (__value * __value))
        {
            sw.WriteLine("right");
        }
        else
        {
            sw.WriteLine("wrong");
        }
    }
}

sw.Close();
