int n = int.Parse(Console.ReadLine());
int[] lengths = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] costs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

// 숫자 표현 가능 범위로 인한 실패 주의.
long min = 0;
long result = 0;

for (int i = 0; i < n - 1; i++)
{
    if (i == 0)
    {
        min = costs[i];
    }
    else
    {
        if (min > costs[i])
        {
            min = costs[i];
        }
    }

    result += (min * lengths[i]);
}

Console.WriteLine(result);