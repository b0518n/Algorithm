StreamWriter sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
int x = int.Parse(Console.ReadLine());

int[] arr = new int[1000001];
int[] index = new int[1000001];

int value1 = 0;
int value2 = 0;
int value3 = 0;

for (int i = 1; i <= 1000000; i++)
{
    value1 = i * 3;
    value2 = i * 2;
    value3 = i + 1;

    if (value1 >= 1 && value1 <= 1000000)
    {
        if (arr[value1] == 0)
        {
            arr[value1] = arr[i] + 1;
            index[value1] = i;
        }
        else
        {
            if (arr[value1] > arr[i] + 1)
            {
                arr[value1] = arr[i] + 1;
                index[value1] = i;
            }
        }
    }

    if (value2 >= 1 && value2 <= 1000000)
    {
        if (arr[value2] == 0)
        {
            arr[value2] = arr[i] + 1;
            index[value2] = i;
        }
        else
        {
            if (arr[value2] > arr[i] + 1)
            {
                arr[value2] = arr[i] + 1;
                index[value2] = i;
            }
        }
    }

    if (value3 >= 1 && value3 <= 1000000)
    {
        if (arr[value3] == 0)
        {
            arr[value3] = arr[i] + 1;
            index[value3] = i;
        }
        else
        {
            if (arr[value3] > arr[i] + 1)
            {
                arr[value3] = arr[i] + 1;
                index[value3] = i;
            }
        }
    }
}

sw.WriteLine(arr[x]);
sw.Write(x);

int temp = x;
while (temp != 1)
{
    sw.Write(" " + index[temp]);
    temp = index[temp];
}

sw.Flush();
sw.Close();