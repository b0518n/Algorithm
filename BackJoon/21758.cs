StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

int n = 0;
int[] arr = null;
int sum = 0;
int result = 0;

Input();
result = GetMaxHoney(0);
result = Math.Max(result, GetMaxHoney(1));
result = Math.Max(result, GetMaxHoney(2));
Print();


void Input()
{
    n = int.Parse(sr.ReadLine());
    arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

    for (int i = 0; i < n; i++)
    {
        sum += arr[i];
    }
}
int GetMaxHoney(int pos)
{
    int first = 0;
    int second = 0;
    int retValue = 0;

    if (pos == 0) // 벌통의 위치 왼쪽
    {
        first = sum - arr[n - 1] - arr[n - 2];
        second = first;
        retValue = first + second;

        int index = n - 3;

        while (index >= 0)
        {
            first -= arr[index];
            second += (arr[index + 1] - arr[index]);

            retValue = Math.Max(retValue, first + second);
            index--;
        }
    }
    else if (pos == 1) // 벌통의 위치 오른쪽
    {
        first = sum - arr[0] - arr[1];
        second = first;
        retValue = first + second;

        int index = 2;

        while (index <= n - 1)
        {
            first += (arr[index - 1] - arr[index]);
            second -= arr[index];

            retValue = Math.Max(retValue, first + second);
            index++;
        }
    }
    else if (pos == 2) // 벌 벌통 벌
    {
        int index = 1;
        int maxValue = -1;

        while (index < n - 1)
        {
            if (maxValue == -1)
            {
                maxValue = arr[index];
            }
            else
            {
                maxValue = Math.Max(maxValue, arr[index]);
            }

            index++;
        }

        retValue = sum - arr[0] - arr[n - 1] + maxValue;
    }

    return retValue;
}
void Print()
{
    sw.WriteLine(result);
    sw.Flush();
    sw.Close();
}