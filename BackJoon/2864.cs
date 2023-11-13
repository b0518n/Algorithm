int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int a = input[0];
int b = input[1];

char[] tempArr = a.ToString().ToArray();

int[] arr1 = new int[tempArr.Length];

for (int i = 0; i < tempArr.Length; i++)
{
    arr1[i] = (int)tempArr[i] - 48;
}

tempArr = b.ToString().ToArray();
int[] arr2 = new int[tempArr.Length];

for (int i = 0; i < tempArr.Length; i++)
{
    arr2[i] = (int)tempArr[i] - 48;
}

int min = 0;
int max = 0;

int digit = 1;

for (int i = arr1.Length - 1; i >= 0; i--)
{
    if (arr1[i] == 6)
    {
        min += (5 * digit);
        max += (arr1[i] * digit);
    }
    else if (arr1[i] == 5)
    {
        min += (arr1[i] * digit);
        max += (6 * digit);
    }
    else
    {
        min += (arr1[i] * digit);
        max += (arr1[i] * digit);
    }

    digit *= 10;
}

digit = 1;

for (int i = arr2.Length - 1; i >= 0; i--)
{
    if (arr2[i] == 6)
    {
        min += (5 * digit);
        max += (arr2[i] * digit);
    }
    else if (arr2[i] == 5)
    {
        min += (arr2[i] * digit);
        max += (6 * digit);
    }
    else
    {
        min += (arr2[i] * digit);
        max += (arr2[i] * digit);
    }

    digit *= 10;
}

Console.WriteLine($"{min} {max}");