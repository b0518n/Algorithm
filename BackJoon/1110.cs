using System.Text;
using System;

int count = 0;

string input = Console.ReadLine();
int value = int.Parse(input);
int tmp = value;

int first = 0;
int second = 0;

while (true)
{
    if (count == 0)
    {
        if (tmp >= 10)
        {
            first = tmp / 10;
            second = tmp % 10;
            if (first + second >= 10)
            {
                tmp = second * 10 + ((first + second) % 10);
            }
            else
            {
                tmp = second * 10 + (first + second);
            }

            count += 1;
        }
        else
        {
            first = 0;
            second = tmp % 10;
            tmp = second * 10 + (first + second);
            count += 1;
        }
    }
    else
    {
        if (tmp == value)
        {
            Console.WriteLine(count);
            break;
        }
        else
        {
            if (tmp >= 10)
            {
                first = tmp / 10;
                second = tmp % 10;
                if (first + second >= 10)
                {
                    tmp = second * 10 + ((first + second) % 10);
                }
                else
                {
                    tmp = second * 10 + (first + second);
                }

                count += 1;
            }
            else
            {
                first = 0;
                second = tmp % 10;
                if (first + second >= 10)
                {
                    tmp = second * 10 + ((first + second) % 10);
                }
                else
                {
                    tmp = second * 10 + (first + second);
                }
                count += 1;
            }
        }
    }
}
