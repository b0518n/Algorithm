int n = int.Parse(Console.ReadLine());
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

int index = 0;
int end = arr.Length - 1;
int cnt = 0; // 현재 봉우리에서 처치한 적의 숫자
int result = -1; // 출력 값 (처치할 수 있는 적의 최대 숫자)
int value = 0; // 처음 봉우리의 높이

while (true)
{
    // 배열의 범위를 넘어갔을 경우
    if (index > end)
    {
        break;
    }

    // 이전의 봉우리보다 작은 봉우리의 경우 무조건 이전의 최대 높이 봉우리보다 적을 더 처치할 수 없기 때문에
    // 불필요한 처리를 줄이기 위함.
    if (value >= arr[index])
    {
        index++;
        continue;
    }

    value = arr[index];

    for (int i = index + 1; ; i++)
    {
        if (i > end) // 배열의 범위를 넘어갔을 때
        {
            InitResult();
            break;
        }

        if (value <= arr[i]) // 자신보다 크거나 같은 높이의 봉우리의 적 처리
        {
            InitResult();
            break;
        }
        else // 자신보다 작은 봉우리에 있는 적 처리
        {
            cnt++;
        }
    }

    index++;
    cnt = 0;
}

Console.WriteLine(result);

void InitResult()
{
    if (result == -1)
    {
        result = cnt;
    }
    else
    {
        result = Math.Max(result, cnt);
    }

    return;
}