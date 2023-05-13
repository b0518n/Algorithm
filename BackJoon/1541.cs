/*
1. '-'가 없을 때
2. '-'가 있을 때 : - 부호가 1개든 여러 개든 상관없이 - 이후의 숫자는 모두 더하고 음수 부호를 붙이는 방법을 이용.
*/
string input = Console.ReadLine();
bool containMinus = false;
int index = 0;
int result = 0;
for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '-')
    {
        containMinus = true;
        break;
    }
    else if (input[i] == '+')
    {
        index++;
    }
}

if (containMinus == true)
{
    input = input.Replace('-', '+');
    int[] values = Array.ConvertAll(input.Split('+'), int.Parse);
    int first = 0;
    int second = 0;
    for (int j = 0; j < values.Length; j++)
    {
        if (j <= index)
        {
            first += values[j];
        }
        else
        {
            second += values[j];
        }
    }

    result = first - second;
}
else
{
    int[] values = Array.ConvertAll(input.Split('+'), int.Parse);
    foreach (int value in values)
    {
        result += value;
    }
}

Console.WriteLine(result);