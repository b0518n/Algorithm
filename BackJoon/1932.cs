int n = int.Parse(Console.ReadLine());
int[] input = null;
int[][] arr = new int[n][];
for (int i = 0; i < n; i++)
{
    input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    arr[i] = input;
}

int[][] result = DeepCopy(arr);

for (int i = arr.Length - 1; i >= 1; i--)
{
    for (int j = 0; j < arr[i].Length; j++)
    {
        if (j == 0)
        {
            arr[i - 1][0] = result[i - 1][0] + arr[i][j];
        }
        else if (j == arr[i].Length - 1)
        {
            int value = result[i - 1][arr[i].Length - 2] + arr[i][j];
            if (arr[i - 1][arr[i].Length - 2] < value)
            {
                arr[i - 1][arr[i].Length - 2] = result[i - 1][arr[i].Length - 2] + arr[i][j];
            }
        }
        else
        {
            int value1 = result[i - 1][j - 1] + arr[i][j];
            int value2 = result[i - 1][j] + arr[i][j];
            if (arr[i - 1][j - 1] < value1)
            {
                arr[i - 1][j - 1] = value1;
            }

            arr[i - 1][j] = value2;
        }
    }
    result = DeepCopy(arr);
}

Console.WriteLine(arr[0][0]);

int[][] DeepCopy(int[][] array)
{
    int[][] temp = new int[array.Length][];
    for (int i = 0; i < arr.Length; i++)
    {
        temp[i] = new int[arr[i].Length];
        for (int j = 0; j < arr[i].Length; j++)
        {
            temp[i][j] = array[i][j];
        }
    }

    return temp;
}